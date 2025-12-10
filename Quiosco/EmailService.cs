using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Quiosco
{
    public class EmailService
    {
        private readonly string smtpHost;
        private readonly int smtpPort;
        private readonly string smtpUser;
        private readonly string smtpPass;

        public EmailService(string host, int port, string user, string pass)
        {
            smtpHost = host;
            smtpPort = port;
            smtpUser = user;
            smtpPass = pass;
        }

        public async Task SendRecoveryCodeAsync(string toEmail, string code)
        {
            var message = new MailMessage();
            message.From = new MailAddress(smtpUser);
            message.To.Add(toEmail);
            message.Subject = "Código de recuperación";
            message.Body = $"Tu código es: {code}";

            using (var client = new SmtpClient(smtpHost, smtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(smtpUser, smtpPass);
                await client.SendMailAsync(message);
            }
        }
    }
}
