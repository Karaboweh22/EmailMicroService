using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task SendPasswordResetLinkAsync(string email)
    {
        // Generate a password reset token
        // For simplicity, using a placeholder token. In a real application, generate a secure token.
        var resetToken = Guid.NewGuid().ToString();

        // Create a password reset link
        var resetLink = $"https://yourdomain.com/reset-password?token={resetToken}";

        // Create a SendGrid client
        var client = new SendGridClient(_configuration["SendGrid:ApiKey"]);

        // Create the email message
        var msg = new SendGridMessage
        {
            From = new EmailAddress("karabomotshosa@gmail.com", "Support"),
            Subject = "Password Reset Request",
            HtmlContent = $"Please reset your password using the following link: <a href=\"{resetLink}\">{resetLink}</a>"
        };

        // Add recipient
        msg.AddTo(new EmailAddress(email));

        // Send the email
        var response = await client.SendEmailAsync(msg);

        // Check the response status
        if (response.StatusCode != System.Net.HttpStatusCode.Accepted)
        {
            // Log the response or handle the failure as needed
            throw new Exception("Failed to send password reset email");
        }
    }
}
