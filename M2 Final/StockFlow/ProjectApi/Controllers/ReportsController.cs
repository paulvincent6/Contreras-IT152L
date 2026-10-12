using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/reports")]
    public class ReportsController : ControllerBase
    {
        private readonly string _connectionString;

        public ReportsController(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/reports/inventory
        [HttpGet("inventory")]
        public async Task<IActionResult> GetInventoryReport()
        {
            var products = new List<object>();

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT
                    Code,
                    Name,
                    Brand,
                    Category,
                    UnitPrice,
                    Quantity,
                    ReorderLevel,
                    CAST(Quantity AS DECIMAL(18,2))
                        * UnitPrice AS StockValue
                  FROM dbo.Items
                  ORDER BY Code",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                int quantity = reader.GetInt32(5);
                int reorderLevel = reader.GetInt32(6);

                products.Add(new
                {
                    Code = reader.GetString(0),
                    Name = reader.GetString(1),
                    Brand = reader.GetString(2),
                    Category = reader.GetString(3),
                    UnitPrice = reader.GetDecimal(4),
                    Quantity = quantity,
                    ReorderLevel = reorderLevel,
                    StockValue = reader.GetDecimal(7),
                    StockStatus = quantity == 0
                        ? "Out of Stock"
                        : quantity <= reorderLevel
                            ? "Low Stock"
                            : "In Stock"
                });
            }

            return Ok(products);
        }


        // GET: api/reports/sales
        [HttpGet("sales")]
        public async Task<IActionResult> GetSalesReport()
        {
            var sales = new List<object>();
            decimal totalRevenue = 0;

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT
                    SaleId,
                    SaleDate,
                    TotalAmount
                  FROM dbo.Sales
                  ORDER BY SaleDate DESC, SaleId DESC",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                decimal amount = reader.GetDecimal(2);
                totalRevenue += amount;

                sales.Add(new
                {
                    SaleId = reader.GetInt32(0),
                    SaleDate = reader.GetDateTime(1),
                    TotalAmount = amount
                });
            }

            return Ok(new
            {
                TotalSales = sales.Count,
                TotalRevenue = totalRevenue,
                Sales = sales
            });
        }


        // GET: api/reports/stockmovements
        [HttpGet("stockmovements")]
        public async Task<IActionResult> GetStockMovementReport()
        {
            var movements = new List<object>();

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT
                    sm.MovementId,
                    sm.ItemCode,
                    i.Name AS ProductName,
                    sm.MovementType,
                    sm.Quantity,
                    sm.Reason,
                    sm.MovementDate
                  FROM dbo.StockMovements sm
                  INNER JOIN dbo.Items i
                      ON sm.ItemCode = i.Code
                  ORDER BY sm.MovementDate DESC,
                           sm.MovementId DESC",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                movements.Add(new
                {
                    MovementId = reader.GetInt32(0),
                    ItemCode = reader.GetString(1),
                    ProductName = reader.GetString(2),
                    MovementType = reader.GetString(3),
                    Quantity = reader.GetInt32(4),
                    Reason = reader.IsDBNull(5)
                        ? null
                        : reader.GetString(5),
                    MovementDate = reader.GetDateTime(6)
                });
            }

            return Ok(new
            {
                TotalMovements = movements.Count,
                Movements = movements
            });
        }


    }


}
