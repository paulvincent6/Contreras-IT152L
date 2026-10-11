using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using ProjectApi.Models;
using System.Data;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/items")]
    public class ItemsController : ControllerBase
    {
        private readonly string _connectionString;

        public ItemsController(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException("Database connection is missing.");
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = new List<Item>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                "SELECT Code, Name, Brand, UnitPrice FROM Items ORDER BY Name",
                connection);

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                items.Add(new Item
                {
                    Code = reader.GetString(0),
                    Name = reader.GetString(1),
                    Brand = reader.GetString(2),
                    UnitPrice = reader.GetDecimal(3)
                });
            }

            return Ok(items);
        }

        // GET: api/items/ITM001
        [HttpGet("{code}")]
        public async Task<ActionResult<Item>> GetItem(string code)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                "SELECT Code, Name, Brand, UnitPrice FROM Items WHERE Code = @Code",
                connection);

            command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = code;

            using var reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return NotFound("Item not found.");

            var item = new Item
            {
                Code = reader.GetString(0),
                Name = reader.GetString(1),
                Brand = reader.GetString(2),
                UnitPrice = reader.GetDecimal(3)
            };

            return Ok(item);
        }

        // POST: api/items
        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            if (!IsValidItem(item))
                return BadRequest("All fields are required and price cannot be negative.");

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"INSERT INTO Items (Code, Name, Brand, UnitPrice)
                  VALUES (@Code, @Name, @Brand, @UnitPrice)",
                connection);

            AddItemParameters(command, item);

            try
            {
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex) when (ex.Number == 2627 || ex.Number == 2601)
            {
                return Conflict("An item with this code already exists.");
            }

            return CreatedAtAction(nameof(GetItem),
                new { code = item.Code }, item);
        }

        // PUT: api/items/ITM001
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateItem(string code, Item item)
        {
            if (!IsValidItem(item) ||
                !string.Equals(code, item.Code, StringComparison.OrdinalIgnoreCase))
                return BadRequest("Invalid item data or mismatched item code.");

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"UPDATE Items
                  SET Name = @Name,
                      Brand = @Brand,
                      UnitPrice = @UnitPrice
                  WHERE Code = @Code",
                connection);

            AddItemParameters(command, item);

            int rows = await command.ExecuteNonQueryAsync();

            if (rows == 0)
                return NotFound("Item not found.");

            return NoContent();
        }

        // DELETE: api/items/ITM001
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteItem(string code)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                "DELETE FROM Items WHERE Code = @Code",
                connection);

            command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = code;

            int rows = await command.ExecuteNonQueryAsync();

            if (rows == 0)
                return NotFound("Item not found.");

            return NoContent();
        }

        private static bool IsValidItem(Item item)
        {
            return item != null
                && !string.IsNullOrWhiteSpace(item.Code)
                && !string.IsNullOrWhiteSpace(item.Name)
                && !string.IsNullOrWhiteSpace(item.Brand)
                && item.Code.Length <= 50
                && item.Name.Length <= 150
                && item.Brand.Length <= 100
                && item.UnitPrice >= 0;
        }

        private static void AddItemParameters(SqlCommand command, Item item)
        {
            command.Parameters.Add("@Code", SqlDbType.NVarChar, 50).Value = item.Code;
            command.Parameters.Add("@Name", SqlDbType.NVarChar, 150).Value = item.Name;
            command.Parameters.Add("@Brand", SqlDbType.NVarChar, 100).Value = item.Brand;

            var price = command.Parameters.Add("@UnitPrice", SqlDbType.Decimal);
            price.Precision = 18;
            price.Scale = 2;
            price.Value = item.UnitPrice;
        }
    }
}
