using Consulting_Server.Models.BaseModels;
using MailKit.Net.Smtp;
using System;
using MimeKit;

namespace Consulting_Server.Models
{
    public class MessageFromUser: BaseEntity
    {
        public string TextMessage { get; set; }

        public void SendEmail(string recipientEmail, string messageBody)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Your Name", "your_email@example.com")); // Вам нужно указать ваше имя и ваш электронный адрес
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = ""; // Тема письма (по вашему требованию не используется)
                message.Body = new TextPart("plain")
                {
                    Text = messageBody
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.example.com", 587, false); // Вам нужно указать SMTP сервер и порт
                    client.Authenticate("your_smtp_username", "your_smtp_password"); // Вам нужно указать ваше имя пользователя и пароль
                    client.Send(message);
                    client.Disconnect(true);
                    Console.WriteLine("Email sent successfully to: " + recipientEmail);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
