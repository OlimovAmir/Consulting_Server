using Consulting_Server.Models.BaseModels;
using System.Net;
using System.Net.Mail;
using System;

namespace Consulting_Server.Models
{
    public class MessageFromUser: BaseEntity
    {
        public string TextMessage { get; set; }
        //var email = new MimeMessage();
        public void SendEmail(string recipientEmail, string messageBody)
        {

            try
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
                        Console.WriteLine("Email sent successfully to: " + recipientEmail);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
