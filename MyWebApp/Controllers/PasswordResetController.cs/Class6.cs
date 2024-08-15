using Microsoft.AspNetCore.Mvc;
using EmailMicroservice.Services; // Ensure this namespace matches where your services are located
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System;

namespace EmailMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PasswordResetController : ControllerBase
    {
        private readonly IEmailService _emailService;

        public PasswordResetController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Call the service to send the password reset link
                bool emailSent = await _emailService.SendPasswordResetLinkAsync(request.Email);

                if (emailSent)
                {
                    return Ok(new { message = "Password reset link sent" });
                }
                else
                {
                    return StatusCode(500, new { message = "Failed to send password reset link" });
                }
            }
            catch (Exception ex)
            {
                // Log the exception (you might want to use a logging framework here)
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }

    public class ForgotPasswordRequest
    {
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address format.")]
        public string Email { get; set; }
    }
}

