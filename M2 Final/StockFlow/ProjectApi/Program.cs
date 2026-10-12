
namespace ProjectApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Register controller services
            builder.Services.AddControllers();

            // Register OpenAPI services
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Enable OpenAPI in development
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            // Redirect HTTP to HTTPS
            app.UseHttpsRedirection();

            // Map API controller endpoints
            app.MapControllers();

            // Start the Web API
            app.Run();
        }
    }
}
    