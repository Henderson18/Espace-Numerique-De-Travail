using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ENAapp.Repositories.implementtation
{
    public class EmailSender : IEmailSender
    {
        private readonly IConfiguration _configuration;

        public EmailSender(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string serveur = _configuration["mail:SmtpServeur"];

            string myEmail = _configuration["mail:SmtpUtilisateur"];

            string password = _configuration["mail:SmtpPassword"];


            var mail = new MimeMessage();

            mail.From.Add(new MailboxAddress("ENT-UY1", myEmail));

            mail.To.Add(new MailboxAddress("ENT-UY1",email));

            mail.Subject = subject;

            mail.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            using (var client = new SmtpClient())
            {
                client.Connect(serveur, 587, false);

                client.Authenticate(myEmail, password);

              await client.SendAsync(mail);

                client.Disconnect(true);
            }
        }
    }
}
