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
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/items
        [HttpGet]
        public async Task<ActionResult<List<Item>>> GetItems()
        {
            var items = new List<Item>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT Code, Name, Brand, Category,
                         UnitPrice, Quantity, ReorderLevel
                  FROM dbo.Items
                  ORDER BY Code",
                connection);

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                items.Add(ReadItem(reader));
            }

            return Ok(items);
        }

        // GET: api/items/ITM0001
        [HttpGet("{code}")]
        public async Task<ActionResult<Item>> GetItem(string code)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT Code, Name, Brand, Category,
                         UnitPrice, Quantity, ReorderLevel
                  FROM dbo.Items
                  WHERE Code = @Code",
                connection);

            command.Parameters.Add("@Code", SqlDbType.NVarChar, 20)
                .Value = code;

            using var reader = await command.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return NotFound("Item not found.");

            return Ok(ReadItem(reader));
        }

        // POST: api/items
        // Automatically generates Item Code
        [HttpPost]
        public async Task<IActionResult> CreateItem(Item item)
        {
            if (item == null)
                return BadRequest("Product information is required.");

            // Ignore any manually submitted Item Code.
            item.Code = "";

            if (!IsValidItem(item, requireCode: false))
                return BadRequest("Invalid product information.");

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            // Generate a unique Item Code.
            item.Code = await GenerateItemCodeAsync(connection);

            using var command = new SqlCommand(
                @"INSERT INTO dbo.Items
                    (Code, Name, Brand, Category,
                     UnitPrice, Quantity, ReorderLevel)
                  VALUES
                    (@Code, @Name, @Brand, @Category,
                     @UnitPrice, 0, @ReorderLevel)",
                connection);

            AddItemParameters(command, item);

            try
            {
                await command.ExecuteNonQueryAsync();
            }
            catch (SqlException ex) when (
                ex.Number == 2627 || ex.Number == 2601)
            {
                return Conflict("Product code already exists.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return BadRequest(
                    "Category does not exist. Select a valid category.");
            }

            item.Quantity = 0;

            return CreatedAtAction(
                nameof(GetItem),
                new { code = item.Code },
                item);
        }

        // PUT: api/items/ITM0001
        [HttpPut("{code}")]
        public async Task<IActionResult> UpdateItem(
            string code, Item item)
        {
            if (!IsValidItem(item) ||
                !string.Equals(
                    code,
                    item.Code,
                    StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(
                    "Invalid product information or mismatched code.");
            }

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"UPDATE dbo.Items
                  SET Name = @Name,
                      Brand = @Brand,
                      Category = @Category,
                      UnitPrice = @UnitPrice,
                      ReorderLevel = @ReorderLevel
                  WHERE Code = @Code",
                connection);

            AddItemParameters(command, item);

            try
            {
                int rows = await command.ExecuteNonQueryAsync();

                if (rows == 0)
                    return NotFound("Item not found.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return BadRequest(
                    "Category does not exist. Select a valid category.");
            }

            return NoContent();
        }

        // DELETE: api/items/ITM0001
        [HttpDelete("{code}")]
        public async Task<IActionResult> DeleteItem(string code)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                "DELETE FROM dbo.Items WHERE Code = @Code",
                connection);

            command.Parameters.Add("@Code", SqlDbType.NVarChar, 20)
                .Value = code;

            try
            {
                int rows = await command.ExecuteNonQueryAsync();

                if (rows == 0)
                    return NotFound("Item not found.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return Conflict(
                    "Cannot delete a product with transaction history.");
            }

            return NoContent();
        }

        // AUTOMATIC ITEM CODE GENERATOR
        private static async Task<string> GenerateItemCodeAsync(
            SqlConnection connection)
        {
            using var command = new SqlCommand(
                "SELECT NEXT VALUE FOR dbo.ItemCodeSequence",
                connection);

            int nextNumber = Convert.ToInt32(
                await command.ExecuteScalarAsync());

            return $"ITM{nextNumber:D4}";
        }

        // Convert SQL data into an Item object
        private static Item ReadItem(SqlDataReader reader)
        {
            return new Item
            {
                Code = reader.GetString(0),
                Name = reader.GetString(1),
                Brand = reader.GetString(2),
                Category = reader.GetString(3),
                UnitPrice = reader.GetDecimal(4),
                Quantity = reader.GetInt32(5),
                ReorderLevel = reader.GetInt32(6)
            };
        }

        // Validate product information
        private static bool IsValidItem(
            Item item, bool requireCode = true)
        {
            return item != null
                && (!requireCode ||
                    !string.IsNullOrWhiteSpace(item.Code))
                && !string.IsNullOrWhiteSpace(item.Name)
                && !string.IsNullOrWhiteSpace(item.Brand)
                && !string.IsNullOrWhiteSpace(item.Category)
                && item.Code.Length <= 20
                && item.Name.Length <= 100
                && item.Brand.Length <= 100
                && item.Category.Length <= 50
                && item.UnitPrice >= 0
                && item.UnitPrice <= 9999999999999999.99m
                && decimal.Round(item.UnitPrice, 2) == item.UnitPrice
                && item.ReorderLevel >= 0;
        }

        // SQL parameters
        private static void AddItemParameters(
            SqlCommand command, Item item)
        {
            command.Parameters.Add(
                "@Code", SqlDbType.NVarChar, 20).Value = item.Code;

            command.Parameters.Add(
                "@Name", SqlDbType.NVarChar, 100).Value = item.Name;

            command.Parameters.Add(
                "@Brand", SqlDbType.NVarChar, 100).Value = item.Brand;

            command.Parameters.Add(
                "@Category", SqlDbType.NVarChar, 50).Value = item.Category;

            var price = command.Parameters.Add(
                "@UnitPrice", SqlDbType.Decimal);

            price.Precision = 18;
            price.Scale = 2;
            price.Value = item.UnitPrice;

            command.Parameters.Add(
                "@ReorderLevel", SqlDbType.Int)
                .Value = item.ReorderLevel;
        }
    }
}
