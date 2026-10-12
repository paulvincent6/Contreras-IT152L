using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectApi.Models;
using System.Data;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SalesController : ControllerBase
    {
        private readonly string _connectionString;

        public SalesController(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/sales
        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            var sales = new List<object>();

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT SaleId, SaleDate, TotalAmount
                  FROM dbo.Sales
                  ORDER BY SaleId DESC",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                sales.Add(new
                {
                    SaleId = reader.GetInt32(0),
                    SaleDate = reader.GetDateTime(1),
                    TotalAmount = reader.GetDecimal(2)
                });
            }

            return Ok(sales);
        }

        // GET: api/sales/1
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSale(int id)
        {
            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            int saleId;
            DateTime saleDate;
            decimal totalAmount;

            using (var command = new SqlCommand(
                @"SELECT SaleId, SaleDate, TotalAmount
                  FROM dbo.Sales
                  WHERE SaleId = @SaleId",
                connection))
            {
                command.Parameters.Add("@SaleId", SqlDbType.Int)
                    .Value = id;

                using var reader =
                    await command.ExecuteReaderAsync();

                if (!await reader.ReadAsync())
                    return NotFound("Sale not found.");

                saleId = reader.GetInt32(0);
                saleDate = reader.GetDateTime(1);
                totalAmount = reader.GetDecimal(2);
            }

            var items = new List<object>();

            using (var command = new SqlCommand(
                @"SELECT ItemCode, Quantity, UnitPrice, Subtotal
                  FROM dbo.SaleDetails
                  WHERE SaleId = @SaleId
                  ORDER BY SaleDetailId",
                connection))
            {
                command.Parameters.Add("@SaleId", SqlDbType.Int)
                    .Value = id;

                using var reader =
                    await command.ExecuteReaderAsync();

                while (await reader.ReadAsync())
                {
                    items.Add(new
                    {
                        ItemCode = reader.GetString(0),
                        Quantity = reader.GetInt32(1),
                        UnitPrice = reader.GetDecimal(2),
                        Subtotal = reader.GetDecimal(3)
                    });
                }
            }

            return Ok(new
            {
                SaleId = saleId,
                SaleDate = saleDate,
                TotalAmount = totalAmount,
                Items = items
            });
        }

        // POST: api/sales
        [HttpPost]
        public async Task<IActionResult> CreateSale(
            SaleRequest request)
        {
            if (request?.Items == null ||
                request.Items.Count == 0)
            {
                return BadRequest(
                    "A sale must contain at least one product.");
            }

            if (request.Items.Any(item =>
                item == null ||
                string.IsNullOrWhiteSpace(item.ItemCode) ||
                item.ItemCode.Length > 20 ||
                item.Quantity <= 0))
            {
                return BadRequest(
                    "Each product must have a valid code " +
                    "and a quantity greater than zero.");
            }

            // Combine repeated product codes.
            var saleItems = request.Items
                .GroupBy(
                    item => item.ItemCode.Trim(),
                    StringComparer.OrdinalIgnoreCase)
                .Select(group => new
                {
                    ItemCode = group.Key,
                    Quantity = group.Sum(
                        item => (long)item.Quantity)
                })
                .OrderBy(item => item.ItemCode)
                .ToList();

            if (saleItems.Any(item =>
                item.Quantity > int.MaxValue))
            {
                return BadRequest(
                    "Requested quantity is too large.");
            }

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var transaction =
                (SqlTransaction)await connection
                    .BeginTransactionAsync(
                        IsolationLevel.Serializable);

            try
            {
                var processedItems =
                    new List<(string Code, int Quantity,
                              decimal Price, decimal Subtotal)>();

                decimal totalAmount = 0;

                foreach (var item in saleItems)
                {
                    int quantity = (int)item.Quantity;

                    // Read price and lock product row.
                    decimal unitPrice;

                    using (var priceCommand = new SqlCommand(
                        @"SELECT UnitPrice
                          FROM dbo.Items WITH (UPDLOCK, HOLDLOCK)
                          WHERE Code = @Code",
                        connection, transaction))
                    {
                        priceCommand.Parameters.Add(
                            "@Code", SqlDbType.NVarChar, 20)
                            .Value = item.ItemCode;

                        object? result =
                            await priceCommand.ExecuteScalarAsync();

                        if (result == null)
                        {
                            await transaction.RollbackAsync();

                            return NotFound(
                                $"Product {item.ItemCode} not found.");
                        }

                        unitPrice = (decimal)result;
                    }

                    // Deduct inventory only when sufficient.
                    using (var stockCommand = new SqlCommand(
                        @"UPDATE dbo.Items
                          SET Quantity = Quantity - @Quantity
                          WHERE Code = @Code
                            AND Quantity >= @Quantity",
                        connection, transaction))
                    {
                        stockCommand.Parameters.Add(
                            "@Code", SqlDbType.NVarChar, 20)
                            .Value = item.ItemCode;

                        stockCommand.Parameters.Add(
                            "@Quantity", SqlDbType.Int)
                            .Value = quantity;

                        int updatedRows =
                            await stockCommand.ExecuteNonQueryAsync();

                        if (updatedRows == 0)
                        {
                            await transaction.RollbackAsync();

                            return BadRequest(
                                $"Insufficient stock for {item.ItemCode}.");
                        }
                    }

                    decimal subtotal =
                        unitPrice * quantity;

                    totalAmount += subtotal;

                    processedItems.Add((
                        item.ItemCode,
                        quantity,
                        unitPrice,
                        subtotal));
                }

                // Create the sale.
                int saleId;

                using (var saleCommand = new SqlCommand(
                    @"INSERT INTO dbo.Sales (TotalAmount)
                      OUTPUT INSERTED.SaleId
                      VALUES (@TotalAmount)",
                    connection, transaction))
                {
                    var totalParameter =
                        saleCommand.Parameters.Add(
                            "@TotalAmount", SqlDbType.Decimal);

                    totalParameter.Precision = 18;
                    totalParameter.Scale = 2;
                    totalParameter.Value = totalAmount;

                    saleId = Convert.ToInt32(
                        await saleCommand.ExecuteScalarAsync());
                }

                // Save sale details and stock movements.
                foreach (var item in processedItems)
                {
                    using (var detailCommand = new SqlCommand(
                        @"INSERT INTO dbo.SaleDetails
                            (SaleId, ItemCode, Quantity, UnitPrice)
                          VALUES
                            (@SaleId, @ItemCode,
                             @Quantity, @UnitPrice)",
                        connection, transaction))
                    {
                        detailCommand.Parameters.Add(
                            "@SaleId", SqlDbType.Int)
                            .Value = saleId;

                        detailCommand.Parameters.Add(
                            "@ItemCode", SqlDbType.NVarChar, 20)
                            .Value = item.Code;

                        detailCommand.Parameters.Add(
                            "@Quantity", SqlDbType.Int)
                            .Value = item.Quantity;

                        var priceParameter =
                            detailCommand.Parameters.Add(
                                "@UnitPrice", SqlDbType.Decimal);

                        priceParameter.Precision = 18;
                        priceParameter.Scale = 2;
                        priceParameter.Value = item.Price;

                        await detailCommand.ExecuteNonQueryAsync();
                    }

                    using (var movementCommand = new SqlCommand(
                        @"INSERT INTO dbo.StockMovements
                            (ItemCode, MovementType,
                             Quantity, Reason)
                          VALUES
                            (@ItemCode, 'OUT',
                             @Quantity, @Reason)",
                        connection, transaction))
                    {
                        movementCommand.Parameters.Add(
                            "@ItemCode", SqlDbType.NVarChar, 20)
                            .Value = item.Code;

                        movementCommand.Parameters.Add(
                            "@Quantity", SqlDbType.Int)
                            .Value = item.Quantity;

                        movementCommand.Parameters.Add(
                            "@Reason", SqlDbType.NVarChar, 200)
                            .Value = $"Sale #{saleId}";

                        await movementCommand.ExecuteNonQueryAsync();
                    }
                }

                await transaction.CommitAsync();

                return StatusCode(201, new
                {
                    SaleId = saleId,
                    TotalAmount = totalAmount,
                    Items = processedItems.Select(item => new
                    {
                        ItemCode = item.Code,
                        Quantity = item.Quantity,
                        UnitPrice = item.Price,
                        Subtotal = item.Subtotal
                    })
                });
            }
            catch (OverflowException)
            {
                await transaction.RollbackAsync();

                return BadRequest(
                    "Sale amount exceeds the allowed range.");
            }
            catch
            {
                try
                {
                    await transaction.RollbackAsync();
                }
                catch
                {
                    // Transaction may already be completed.
                }

                throw;
            }
        }
    }
}
