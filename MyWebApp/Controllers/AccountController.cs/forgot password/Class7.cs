using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class AccountController : Controller
{
    [HttpPost]
    public async Task<IActionResult> ForgotPassword(ForgotPasswordModel model)
    {
        if (ModelState.IsValid)
        {
            try
            {
                using var client = new HttpClient();
                var requestContent = new StringContent(
                    JsonSerializer.Serialize(new { Email = model.Email }),
                    Encoding.UTF8,
                    "application/json"
                );

                var response = await client.PostAsync("https://your-microservice-url/api/passwordreset/forgot", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Password reset link has been sent to your email.";
                }
                else
                {
                    ViewBag.Message = "An error occurred while sending the reset link. Please try again later.";
                }
            }
            catch (Exception ex)
            {
                // Log the exception if needed (consider using a logging framework)
                ViewBag.Message = "An unexpected error occurred: " + ex.Message;
            }
        }
        else
        {
            // If model state is not valid, return the view with the model to display validation errors
            ViewBag.Message = "Please provide a valid email address.";
        }
        return View(model);
    }
}
