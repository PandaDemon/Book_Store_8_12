using System;
using System.Net;
using System.Net.Mail;

namespace Store.BusinessLogic.Services
{
    public class EmailService
    {
        public static string SendMail(string mailAddress, string messageSubject, string messageBody)
        {
            var from = "mpanukov@gmail.com";
            var pass = "mp512055120";
            try
            {
                using (var mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(from);
                    mailMessage.To.Add(new MailAddress(mailAddress));

                    mailMessage.Subject = messageSubject;
                    mailMessage.Body = messageBody;

                    using (var client = new SmtpClient("smtp.mail.ru", 25))
                    {
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(from, pass);
                        client.EnableSsl = true;

                        mailMessage.IsBodyHtml = true;

                        client.Send(mailMessage);
                    }

                }
                var messegeSuccess = $"Email sent to {mailAddress}.\nSubject:{messageSubject}\nBody:{messageBody}";

                return messegeSuccess;
            }
            catch (Exception e)
            {
                var message = String.Format("Cant send mail. Subject: {0}. To: {1}. Body: {2}.",
                    messageSubject, mailAddress, messageBody);

                throw new MailException(message, e);
            }
        }
    }
}
