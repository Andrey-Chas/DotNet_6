using Email_Sending.Models.Emailing;

namespace Email_Sending.Services.Interfaces
{
    public interface IMailService
    {
        Task SendEmailAsync(MailRequest mailRequest);
    }
}
