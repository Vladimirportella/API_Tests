using Projeto.Domain.Contracts.CrossCutting;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Projeto.CrossCutting.Mail
{
    public class EmailMessage : IEmailMessage
    {
        private const string conta = "cotiexemplo2@gmail.com";
        private const string senha = "@coticoti@";
        private const string smtp = "smtp.gmail.com";
        private const int porta = 587;

        public void SendMessage(string mailTo, string subject, string body)
        {
            var mail = new MailMessage(conta, mailTo);
            mail.Subject = subject;
            mail.Body = body;

            var smtpClient = new SmtpClient(smtp, porta);
            smtpClient.Credentials = new NetworkCredential(conta, senha);
            smtpClient.EnableSsl = true;
            smtpClient.Send(mail);
        }
    }
}
