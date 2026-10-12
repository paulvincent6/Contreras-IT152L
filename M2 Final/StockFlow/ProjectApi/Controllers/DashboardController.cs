using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashboardController : ControllerBase
    {
        private readonly string _connectionString;

        public DashboardController(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/dashboard
        [HttpGet]
        public async Task<IActionResult> GetDashboard()
        {
            using var connection =
                new SqlConnection(_connectionString);

            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT
                    (SELECT COUNT(*)
                     FROM dbo.Items) AS TotalProducts,

                    (SELECT ISNULL(SUM(Quantity), 0)
                     FROM dbo.Items) AS TotalStockUnits,

                    (SELECT COUNT(*)
                     FROM dbo.Categories) AS TotalCategories,

                    (SELECT ISNULL(SUM(
                        CAST(Quantity AS DECIMAL(18,2))
                        * UnitPrice), 0)
                     FROM dbo.Items) AS InventoryValue,

                    (SELECT COUNT(*)
                     FROM dbo.Items
                     WHERE Quantity <= ReorderLevel)
                     AS LowStockProducts,

                    (SELECT COUNT(*)
                     FROM dbo.Sales) AS TotalSales,

                    (SELECT ISNULL(SUM(TotalAmount), 0)
                     FROM dbo.Sales) AS TotalRevenue",
                connection);

            using var reader =
                await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return StatusCode(500,
                    "Unable to retrieve dashboard data.");


            return Ok(new
            {
                TotalProducts = reader.GetInt32(0),
                TotalStockUnits = reader.GetInt32(1),
                TotalCategories = reader.GetInt32(2),
                InventoryValue = reader.GetDecimal(3),
                LowStockProducts = reader.GetInt32(4),
                TotalSales = reader.GetInt32(5),
                TotalRevenue = reader.GetDecimal(6)
            });

        }
    }
}
