using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyWebApp.Services; // Ensure this namespace matches where your services are located

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configure services
        builder.Services.AddSingleton<IEmailService>(new EmailService(
            builder.Configuration["SendGrid:ApiKey"],
            builder.Configuration["SendGrid:FromEmail"]
        ));

        builder.Services.AddControllersWithViews();

        // Build the application
        var app = builder.Build();

        // Configure middleware
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors(policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
        app.UseAuthorization();

        app.MapControllers();
        app.Run();
    }
}

