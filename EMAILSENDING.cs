using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

public interface IEmailService
{
    Task<bool> SendPasswordResetLinkAsync(string email);
}

public class EmailService : IEmailService
{
    private readonly string _apiKey;
    private readonly string _fromEmail;

    public EmailService(string apiKey, string fromEmail)
    {
        _apiKey = apiKey;
        _fromEmail = fromEmail;
    }

    public async Task<bool> SendPasswordResetLinkAsync(string email)
    {
        try
        {
            // Initialize SendGrid client with API key
            var client = new SendGridClient(_apiKey);

            // Define the email sender and recipient
            var from = new EmailAddress(_fromEmail, "Your App Name");
            var to = new EmailAddress(email);

            // Define email subject and content
            var subject = "Password Reset Request";
            var resetToken = "exampleToken"; // Replace with actual token generation logic
            var resetLink = $"https://yourdomain.com/reset-password?token={resetToken}";
            var plainTextContent = $"Please reset your password using the following link: {resetLink}";
            var htmlContent = $"<strong>Please reset your password using the following link:</strong> <a href=\"{resetLink}\">{resetLink}</a>";

            // Create the email message
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

            // Send the email
            var response = await client.SendEmailAsync(msg);

            // Check if the email was sent successfully
            return response.StatusCode == System.Net.HttpStatusCode.OK;
        }
        catch (Exception ex)
        {
            // Log or handle the exception as needed
            // You might want to use a logging framework here
            return false;
        }
    }
}

