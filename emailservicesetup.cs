using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public interface IEmailService
{
    Task<bool> SendPasswordResetLinkAsync(string email);
}

public class EmailService : IEmailService
{
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _smtpPort = 465; // Use 465 for SSL, 587 for TLS
    private readonly string _smtpUsername = "karabomotshosa@gmail.com";
    private readonly string _smtpPassword = "Karar!2024$"; // Consider using an app-specific password

    public async Task<bool> SendPasswordResetLinkAsync(string email)
    {
        try
        {
            using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                smtpClient.EnableSsl = true;

                var fromAddress = new MailAddress(_smtpUsername, "Your App Name");
                var toAddress = new MailAddress(email);
                var subject = "Password Reset Request";

                // Replace with actual token generation logic
                var resetToken = "dummyToken";
                var resetLink = $"https://yourdomain.com/reset-password?token={resetToken}";

                var plainTextContent = $"Please reset your password using the following link: {resetLink}";
                var htmlContent = $"<strong>Please reset your password using the following link:</strong> <a href=\"{resetLink}\">{resetLink}</a>";

                var mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = htmlContent,
                    IsBodyHtml = true
                };

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
        }
        catch (Exception ex)
        {
            // Log exception (Consider using a logging library)
            // For example: Console.WriteLine(ex.Message);
            return false;
        }
    }
}

