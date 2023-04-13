using Email_Sending.Models.Emailing;
using Email_Sending.Services.Interfaces;
using Microsoft.Extensions.Options;
using MimeKit;
using System.Net.Mail;

namespace Email_Sending.Services
{
    public class MailService : IMailService
    {
        private readonly MailSettings mailSettings;
        public MailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(mailRequest.ToEmail);
            mail.From = new System.Net.Mail.MailAddress(mailSettings.Mail, mailSettings.DisplayName);
            mail.Subject = mailRequest.Subject;
            mail.Body = mailRequest.Body;

            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("gmail_address", "gmail_password");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            try
            {
                client.Send(mail);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
