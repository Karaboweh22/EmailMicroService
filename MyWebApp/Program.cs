using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.Services.AddHttpClient<PasswordResetService>(client =>
{
    // Configure the HttpClient here if needed, e.g., set a base address
    client.BaseAddress = new Uri("https://your-microservice-url/");
    // You can also set default headers, timeouts, etc.
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure middleware
if (!app.Environment.IsDevelopment())
{
    // Use a global exception handler for production environments
    app.UseExceptionHandler("/Home/Error");
    // Use HSTS (HTTP Strict Transport Security) for added security
    app.UseHsts();
}

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS
app.UseStaticFiles(); // Serve static files (e.g., CSS, JS)

app.UseRouting(); // Enable routing

app.UseAuthentication(); // Enable authentication middleware (if applicable)
app.UseAuthorization(); // Enable authorization middleware

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run(); // Run the application
