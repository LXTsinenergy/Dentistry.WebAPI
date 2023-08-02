using System.Net.Mail;

namespace Dentistry.BLL.Services.MessageService
{
    public interface IMessageService
    {
        Task SendEmailAsync(string email, string message);
    }
}
