using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;

namespace CarMarketplace.Services
{
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
        {
            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Your Name", emailSettings["SenderEmail"]));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;

                message.Body = new TextPart("plain") { Text = body };

                using var client = new SmtpClient();
                await client.ConnectAsync(emailSettings["SmtpServer"], int.Parse(emailSettings["Port"]), false);
                await client.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
                await client.SendAsync(message);
                await client.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                return false;
            }
        }
        public async Task<bool> SendEmailsAsync(string userEmail, string subject, string messageBody)
        {
            try
            {
                var emailSettings = _configuration.GetSection("EmailSettings");

                // Send email to Admin
                var adminMessage = new MimeMessage();
                adminMessage.From.Add(new MailboxAddress("Car Marketplace", emailSettings["SenderEmail"]));  // Sender email and name
                adminMessage.To.Add(new MailboxAddress("Admin", emailSettings["AdminEmail"]));  // Admin's email and name
                adminMessage.Subject = $"New Request from {userEmail} - {subject}";

                var adminBodyBuilder = new BodyBuilder
                {
                    TextBody = $"You have received a new request from {userEmail}:\n\n{messageBody}"
                };
                adminMessage.Body = adminBodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(emailSettings["SmtpServer"], int.Parse(emailSettings["Port"]), false);
                    await client.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
                    await client.SendAsync(adminMessage);
                    await client.DisconnectAsync(true);
                }

                // Send auto-reply to User
                var userMessage = new MimeMessage();
                userMessage.From.Add(new MailboxAddress("Car Marketplace", emailSettings["SenderEmail"]));  // Sender email and name
                userMessage.To.Add(new MailboxAddress("User", userEmail));  // User's email
                userMessage.Subject = "We have received your request";

                var userBodyBuilder = new BodyBuilder
                {
                    TextBody = "Thank you for reaching out! Our team has received your message and will get back to you shortly."
                };
                userMessage.Body = userBodyBuilder.ToMessageBody();

                using (var client = new SmtpClient())
                {
                    await client.ConnectAsync(emailSettings["SmtpServer"], int.Parse(emailSettings["Port"]), false);
                    await client.AuthenticateAsync(emailSettings["SenderEmail"], emailSettings["SenderPassword"]);
                    await client.SendAsync(userMessage);
                    await client.DisconnectAsync(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending emails: {ex.Message}");
                return false;
            }
        }

    }


}
