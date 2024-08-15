using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add CORS policy
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                policy =>
                {
                    policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });

        // Add other services to the container if needed
        builder.Services.AddControllersWithViews(); // Example service

        var app = builder.Build();

        // Configure the HTTP request pipeline
        app.UseCors("AllowAll");

        // Use routing and endpoint mapping
        app.UseRouting();

        app.UseAuthorization();

        app.MapControllers(); // Map controllers to endpoints

        app.Run();
    }
}

