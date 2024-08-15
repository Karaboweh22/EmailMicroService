using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class PasswordResetService
{
    private readonly HttpClient _httpClient;

    public PasswordResetService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    /// <summary>
    /// Sends a password reset request to the external API.
    /// </summary>
    /// <param name="email">The email address to which the password reset link will be sent.</param>
    /// <returns>A boolean indicating whether the request was successful.</returns>
    public async Task<bool> SendForgotPasswordRequestAsync(string email)
    {
        // Serialize the email into JSON format
        var requestContent = new StringContent(
            JsonSerializer.Serialize(new { Email = email }),
            Encoding.UTF8,
            "application/json"
        );

        // Send the POST request to the API
        var response = await _httpClient.PostAsync("api/passwordreset/forgot", requestContent);

        // Return true if the response status code indicates success
        return response.IsSuccessStatusCode;
    }
}

