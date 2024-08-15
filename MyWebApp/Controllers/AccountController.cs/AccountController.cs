using Microsoft.AspNetCore.Mvc;
using MyWebApp.Models; // Ensure this namespace matches where your models are located
using System.Text.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Implement your login logic here
                // Example:
                // var user = _userService.Authenticate(model.Username, model.Password);
                // if (user != null)
                // {
                //     // Set authentication cookie
                //     return RedirectToAction("Index", "Home");
                // }
                // else
                // {
                //     ModelState.AddModelError("", "Invalid login attempt.");
                // }

                // For now, just redirecting to Home.Index as a placeholder
                return RedirectToAction("Index", "Home");
            }

            // If model state is not valid, return the view with the model to display validation errors
            return View(model);
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                using var client = new HttpClient();
                var requestContent = new StringContent(JsonSerializer.Serialize(new { Email = model.Email }), Encoding.UTF8, "application/json");
                var response = await client.PostAsync("https://your-microservice-url/api/passwordreset/forgot", requestContent);

                if (response.IsSuccessStatusCode)
                {
                    ViewBag.Message = "Password reset link has been sent to your email.";
                }
                else
                {
                    ViewBag.Message = "An error occurred while sending the reset link.";
                }
            }
            return View(model);
        }

        //[HttpPost]
        //public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        // Implement your password reset logic here
        //        // Example:
        //        // var result = await _passwordResetService.SendResetLinkAsync(model.Email);
        //        // if (result)
        //        // {
        //        //     ViewBag.Message = "Password reset link has been sent to your email.";
        //        // }
        //        // else
        //        // {
        //        //     ViewBag.Message = "An error occurred while sending the reset link.";
        //        // }

        //        // For now, just redirecting to Login as a placeholder
        //        return RedirectToAction("Login");
        //    }

        //    // If model state is not valid, return the view with the model to display validation errors
        //    return View(model);
        //}
    }
}
