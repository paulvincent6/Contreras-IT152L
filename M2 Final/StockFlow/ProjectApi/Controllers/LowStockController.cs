using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/lowstock")]
    public class LowStockController : ControllerBase
    {
        private readonly string _connectionString;

        public LowStockController(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/lowstock
        [HttpGet]
        public async Task<IActionResult> GetLowStockProducts()
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
                    Quantity,
                    ReorderLevel
                  FROM dbo.Items
                  WHERE Quantity <= ReorderLevel
                  ORDER BY Quantity ASC, Code ASC",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                products.Add(new
                {
                    Code = reader.GetString(0),
                    Name = reader.GetString(1),
                    Brand = reader.GetString(2),
                    Category = reader.GetString(3),
                    Quantity = reader.GetInt32(4),
                    ReorderLevel = reader.GetInt32(5)
                });
            }

            return Ok(products);
        }
    }
}
