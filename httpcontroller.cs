using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models;

public class AccountController : Controller
{
    private readonly HttpClient _httpClient;

    public AccountController(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    [HttpGet]
    public IActionResult ForgotPassword()
    {
        // Display the Forgot Password view
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                // Serialize the email into JSON format
                var requestContent = new StringContent(
                    JsonSerializer.Serialize(new { Email = model.Email }),
                    Encoding.UTF8,
                    "application/json"
                );

                // Send the POST request to the API
                var response = await _httpClient.PostAsync("https://your-microservice-url/api/passwordreset/forgot", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    // Redirect to the confirmation page if successful
                    return RedirectToAction("PasswordResetConfirmation");
                }
                else
                {
                    // Handle error (e.g., show an error message)
                    ModelState.AddModelError(string.Empty, "Failed to send password reset link. Please try again later.");
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed (consider using a logging framework)
                // Example logging:
                // _logger.LogError(ex, "An error occurred while sending the password reset link.");

                ModelState.AddModelError(string.Empty, "An unexpected error occurred: " + ex.Message);
            }
        }

        // If we got this far, something failed; redisplay the form
        return View(model);
    }

    [HttpGet]
    public IActionResult PasswordResetConfirmation()
    {
        // Return a view that confirms the password reset link has been sent
        return View();
    }
}

