using System.Net.Http;
using System.Text;
using System.Text.Json;

// Example usage within a method
public async Task SendPasswordResetRequestAsync(string email)
{
    // Create an anonymous object with the email property
    var requestPayload = new { Email = email };

    // Serialize the anonymous object to JSON
    var jsonContent = JsonSerializer.Serialize(requestPayload);

    // Create StringContent with JSON payload and appropriate media type
    var requestContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

    // Example of using HttpClient to send the request
    using var client = new HttpClient();
    var response = await client.PostAsync("https://your-microservice-url/api/passwordreset/forgot", requestContent);

    // Check response status and handle accordingly
    if (response.IsSuccessStatusCode)
    {
        // Handle success
    }
    else
    {
        // Handle error
    }
}
