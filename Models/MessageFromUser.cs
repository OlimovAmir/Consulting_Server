using Consulting_Server.Models.BaseModels;
using System.Net;
using System.Net.Mail;

namespace Consulting_Server.Models
{
    public class MessageFromUser: BaseEntity
    {
        public void SendEmail(string recipientEmail, string messageBody)
        {
            using (var smtpClient = new SmtpClient("smtp.example.com"))
            {
                smtpClient.Port = 587;
                smtpClient.Credentials = new NetworkCredential("your_smtp_username", "your_smtp_password");
                smtpClient.EnableSsl = true;

                using (var message = new MailMessage())
                {
                    message.To.Add(recipientEmail);
                    message.Body = messageBody;

                    smtpClient.Send(message);
                }
            }
        }
    }
}
