using System;
using System.Net;
using System.Net.Mail;

namespace PrintStore.BusinessLogic.Services
{
    public class EmailService
    {
        private readonly string _from = "fista_shka@mail.ru";
        private readonly string _password = "Fyfcnfcbz1991";

        public void SendEmail(string mailAddress, string messageSubject, string messageBody)
        {
            try
            {
                using (MailMessage mailMessage = new MailMessage())
                {
                    mailMessage.From = new MailAddress(_from);
                    mailMessage.To.Add(new MailAddress(mailAddress));
                    mailMessage.Subject = messageSubject;
                    mailMessage.Body = messageBody;

                    using (SmtpClient client = new SmtpClient("smtp.mail.ru", 25))
                    {
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(_from, _password);
                        client.EnableSsl = true;
                        mailMessage.IsBodyHtml = true;

                        client.Send(mailMessage);
                    }
                }
            }
            catch (Exception e)
            {
                string message = $"Cant send mail. Subject: {messageSubject}. To: {mailAddress}. Body: {messageBody}";

                throw new MailException(message, e);
            }
        }
    }
}
