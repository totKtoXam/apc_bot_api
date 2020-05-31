using System;
using System.Threading.Tasks;
using MimeKit;
using MailKit.Net.Smtp;
using apc_bot_api.Constants;

namespace apc_bot_api.Helpers
{
    public class EmailHelper
    {
        public static async Task SendEmailAsync(string receiverEmail, string subject, string message)
        {
            Console.WriteLine("Email sending operation started...");
            var emailMessage = GetMimeMessage(receiverEmail, subject, message);

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync("smtp.yandex.ru", 25, false);

                await client.AuthenticateAsync(EmailConstants.ToRegistation.Email, EmailConstants.ToRegistation.Password);

                await client.SendAsync(emailMessage);

                await client.DisconnectAsync(true);
            }
        }

        public static MimeMessage GetMimeMessage(string receiverEmail, string subject, string message)
        {
            MimeMessage emailMessage = new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(EmailConstants.ToRegistation.Title, EmailConstants.ToRegistation.Email));
            emailMessage.To.Add(new MailboxAddress("", receiverEmail));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html) { Text = message };
            return emailMessage;
        }
    }
}