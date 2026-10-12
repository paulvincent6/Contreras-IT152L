using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectApi.Models;
using System.Data;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/stockmovements")]
    public class StockMovementsController : ControllerBase
    {
        private readonly string _connectionString;

        public StockMovementsController(
            IConfiguration configuration)
        {
            _connectionString = configuration
                .GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/stockmovements
        [HttpGet]
        public async Task<IActionResult> GetMovements()
        {
            var movements = new List<object>();

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT MovementId, ItemCode,
                         MovementType, Quantity,
                         Reason, MovementDate
                  FROM dbo.StockMovements
                  ORDER BY MovementId DESC",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                movements.Add(new
                {
                    MovementId = reader.GetInt32(0),
                    ItemCode = reader.GetString(1),
                    MovementType = reader.GetString(2),
                    Quantity = reader.GetInt32(3),
                    Reason = reader.IsDBNull(4)
                        ? null : reader.GetString(4),
                    MovementDate = reader.GetDateTime(5)
                });
            }

            return Ok(movements);
        }

        // POST: api/stockmovements
        [HttpPost]
        public async Task<IActionResult> CreateMovement(
            StockMovementRequest request)
        {
            if (request == null ||
                string.IsNullOrWhiteSpace(request.ItemCode) ||
                request.Quantity <= 0 ||
                (request.MovementType?.ToUpperInvariant() != "IN" &&
                 request.MovementType?.ToUpperInvariant() != "OUT"))
            {
                return BadRequest(
                    "Provide a valid item code, IN or OUT type, " +
                    "and a quantity greater than zero.");
            }

            string itemCode = request.ItemCode.Trim();
            string movementType =
                request.MovementType.ToUpperInvariant();
            string? reason = request.Reason?.Trim();

            if (itemCode.Length > 20 ||
                reason?.Length > 200)
            {
                return BadRequest(
                    "Item code or reason exceeds the allowed length.");
            }

            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var transaction =
                (SqlTransaction)await connection
                    .BeginTransactionAsync();

            try
            {
                // Update inventory.
                // For OUT, ensure enough stock exists.
                string updateSql = movementType == "IN"
                    ? @"UPDATE dbo.Items
                        SET Quantity = Quantity + @Quantity
                        WHERE Code = @ItemCode
                          AND Quantity <= 2147483647 - @Quantity"
                    : @"UPDATE dbo.Items
                        SET Quantity = Quantity - @Quantity
                        WHERE Code = @ItemCode
                          AND Quantity >= @Quantity";

                using var updateCommand =
                    new SqlCommand(updateSql,
                        connection, transaction);

                updateCommand.Parameters.Add(
                    "@ItemCode", SqlDbType.NVarChar, 20)
                    .Value = itemCode;

                updateCommand.Parameters.Add(
                    "@Quantity", SqlDbType.Int)
                    .Value = request.Quantity;

                int updatedRows =
                    await updateCommand.ExecuteNonQueryAsync();

                if (updatedRows == 0)
                {
                    using var checkCommand = new SqlCommand(
                        @"SELECT Quantity FROM dbo.Items
                          WHERE Code = @ItemCode",
                        connection, transaction);

                    checkCommand.Parameters.Add(
                        "@ItemCode", SqlDbType.NVarChar, 20)
                        .Value = itemCode;

                    object? currentQuantity =
                        await checkCommand.ExecuteScalarAsync();

                    await transaction.RollbackAsync();

                    if (currentQuantity == null)
                        return NotFound("Product not found.");

                    return BadRequest(movementType == "OUT"
                        ? "Insufficient stock."
                        : "Stock quantity would exceed the maximum allowed.");
                }

                // Record movement history.
                using var insertCommand = new SqlCommand(
                    @"INSERT INTO dbo.StockMovements
                        (ItemCode, MovementType,
                         Quantity, Reason)
                      OUTPUT INSERTED.MovementId
                      VALUES
                        (@ItemCode, @MovementType,
                         @Quantity, @Reason)",
                    connection, transaction);

                insertCommand.Parameters.Add(
                    "@ItemCode", SqlDbType.NVarChar, 20)
                    .Value = itemCode;

                insertCommand.Parameters.Add(
                    "@MovementType", SqlDbType.NVarChar, 10)
                    .Value = movementType;

                insertCommand.Parameters.Add(
                    "@Quantity", SqlDbType.Int)
                    .Value = request.Quantity;

                insertCommand.Parameters.Add(
                    "@Reason", SqlDbType.NVarChar, 200)
                    .Value = (object?)reason ?? DBNull.Value;

                int movementId = Convert.ToInt32(
                    await insertCommand.ExecuteScalarAsync());

                await transaction.CommitAsync();

                return StatusCode(201, new
                {
                    MovementId = movementId,
                    ItemCode = itemCode,
                    MovementType = movementType,
                    Quantity = request.Quantity,
                    Reason = reason
                });
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
