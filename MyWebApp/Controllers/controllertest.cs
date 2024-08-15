using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using System.Threading.Tasks;

public class PasswordResetController : ControllerBase
{
    private readonly IEmailService _emailService;

    // Constructor to inject the email service
    public PasswordResetController(IEmailService emailService)
    {
        _emailService = emailService;
    }

    [HttpPost("forgot")]
    public async Task<IActionResult> ForgotPassword()
    {
        // For demonstration purposes, using a fixed test email address
        var testEmail = "karabomotshosa@gmail.com";

        try
        {
            // Call the email service to send the password reset link
            bool emailSent = await _emailService.SendPasswordResetLinkAsync(testEmail);

            if (emailSent)
            {
                // Return a successful response if the email was sent
                return Ok(new { message = "Password reset link sent" });
            }
            else
            {
                // Return a server error response if the email could not be sent
                return StatusCode(500, new { message = "Failed to send password reset link" });
            }
        }
        catch (Exception ex)
        {
            // Log the exception (consider using a logging framework)
            // Return a server error response with exception details
            return StatusCode(500, new { message = "An unexpected error occurred", error = ex.Message });
        }
    }
}
