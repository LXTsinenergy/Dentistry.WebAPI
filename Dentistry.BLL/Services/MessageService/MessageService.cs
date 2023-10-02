using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System.Data;

namespace Dentistry.BLL.Services.MessageService
{
    public class MessageService : IMessageService
    {
        private readonly IConfiguration _configuration;

        public MessageService(IConfiguration configuration) => _configuration = configuration;

        public async Task SendEmailAsync(string email, string message)
        {
            using var emailMessage = ConfigureEmail(email, message);
            using var client = new SmtpClient();

            await client.ConnectAsync(_configuration.GetSection("Email")["Host"],
                Convert.ToInt32(_configuration.GetSection("Email")["Port"]), true);

            await client.AuthenticateAsync(_configuration.GetSection("Email")["Account"],
                _configuration.GetSection("Email")["Password"]);
            
            await client.SendAsync(emailMessage);
        }

        private MimeMessage ConfigureEmail(string email, string message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_configuration.GetSection("Email")["Message"],
            _configuration.GetSection("Email")["Account"]));
            emailMessage.To.Add(new MailboxAddress("", email));
            emailMessage.Subject = _configuration.GetSection("Email")["Subject"];
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = $"Ваш проверочный код для получения пароля: {message}" };

            return emailMessage;
        }
    }
}
