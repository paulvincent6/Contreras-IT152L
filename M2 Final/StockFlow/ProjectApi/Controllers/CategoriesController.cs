using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ProjectApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly string _connectionString;

        public CategoriesController(IConfiguration configuration)
        {
            _connectionString =
                configuration.GetConnectionString("DefaultConnection")
                ?? throw new InvalidOperationException(
                    "Database connection is missing.");
        }

        // GET: api/categories
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = new List<object>();

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"SELECT CategoryId, CategoryName, Description
                  FROM dbo.Categories
                  ORDER BY CategoryId",
                connection);

            using var reader = await command.ExecuteReaderAsync();

            while (await reader.ReadAsync())
            {
                categories.Add(new
                {
                    CategoryId = reader.GetInt32(0),
                    CategoryName = reader.GetString(1),
                    Description = reader.IsDBNull(2)
                        ? null
                        : reader.GetString(2)
                });
            }

            return Ok(categories);
        }

        // POST: api/categories
        [HttpPost]
        public async Task<IActionResult> CreateCategory(
            CategoryRequest category)
        {
            if (category == null ||
                string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return BadRequest("Category name is required.");
            }

            string categoryName = category.CategoryName.Trim();
            string? description = category.Description?.Trim();

            if (categoryName.Length > 50)
                return BadRequest(
                    "Category name cannot exceed 50 characters.");

            if (description?.Length > 200)
                return BadRequest(
                    "Description cannot exceed 200 characters.");

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"INSERT INTO dbo.Categories
                    (CategoryName, Description)
                  OUTPUT INSERTED.CategoryId
                  VALUES (@CategoryName, @Description)",
                connection);

            command.Parameters.Add(
                "@CategoryName", SqlDbType.NVarChar, 50)
                .Value = categoryName;

            command.Parameters.Add(
                "@Description", SqlDbType.NVarChar, 200)
                .Value = (object?)description ?? DBNull.Value;

            try
            {
                int categoryId = Convert.ToInt32(
                    await command.ExecuteScalarAsync());

                return StatusCode(201, new
                {
                    CategoryId = categoryId,
                    CategoryName = categoryName,
                    Description = description
                });
            }
            catch (SqlException ex) when (
                ex.Number == 2627 || ex.Number == 2601)
            {
                return Conflict("Category already exists.");
            }
        }


        // PUT: api/categories/6
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(
            int id, CategoryRequest category)
        {
            if (category == null ||
                string.IsNullOrWhiteSpace(category.CategoryName))
            {
                return BadRequest("Category name is required.");
            }

            string categoryName = category.CategoryName.Trim();
            string? description = category.Description?.Trim();

            if (categoryName.Length > 50)
                return BadRequest(
                    "Category name cannot exceed 50 characters.");

            if (description?.Length > 200)
                return BadRequest(
                    "Description cannot exceed 200 characters.");

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"UPDATE dbo.Categories
                  SET CategoryName = @CategoryName,
                      Description = @Description
                  WHERE CategoryId = @CategoryId",
                connection);

            command.Parameters.Add("@CategoryId", SqlDbType.Int)
                .Value = id;

            command.Parameters.Add("@CategoryName", SqlDbType.NVarChar, 50)
                .Value = categoryName;

            command.Parameters.Add("@Description", SqlDbType.NVarChar, 200)
                .Value = (object?)description ?? DBNull.Value;

            try
            {
                int rows = await command.ExecuteNonQueryAsync();

                if (rows == 0)
                    return NotFound("Category not found.");
            }
            catch (SqlException ex) when (
                ex.Number == 2627 || ex.Number == 2601)
            {
                return Conflict("Category name already exists.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return Conflict(
                    "Cannot rename a category currently used by products.");
            }

            return NoContent();
        }


        // DELETE: api/categories/6
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            using var command = new SqlCommand(
                @"DELETE FROM dbo.Categories
                  WHERE CategoryId = @CategoryId",
                connection);

            command.Parameters.Add("@CategoryId", SqlDbType.Int)
                .Value = id;

            try
            {
                int rows = await command.ExecuteNonQueryAsync();

                if (rows == 0)
                    return NotFound("Category not found.");
            }
            catch (SqlException ex) when (ex.Number == 547)
            {
                return Conflict(
                    "Cannot delete this category because products are using it.");
            }

            return NoContent();
        }



    }

    public class CategoryRequest
    {
        public string CategoryName { get; set; } = "";
        public string? Description { get; set; }
    }
}
