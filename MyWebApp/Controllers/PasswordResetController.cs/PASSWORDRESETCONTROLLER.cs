using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace MyWebApp.Controllers
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

        /// <summary>
        /// Endpoint to handle password reset requests.
        /// </summary>
        /// <param name="request">Contains the email address for which to send a password reset link.</param>
        /// <returns>An IActionResult indicating the result of the request.</returns>
        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordRequest request)
        {
            // Check if the model state is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Send password reset link
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
                // Return an error response if an exception occurs
                return StatusCode(500, new { message = "An error occurred while processing your request", error = ex.Message });
            }
        }
    }

    /// <summary>
    /// Represents the request model for a password reset.
    /// </summary>
    public class ForgotPasswordRequest
    {
        /// <summary>
        /// Gets or sets the email address to which the password reset link will be sent.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
