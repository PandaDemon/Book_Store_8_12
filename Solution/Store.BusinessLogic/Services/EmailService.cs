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
                using (var mm = new MailMessage())
                {
                    mm.From = new MailAddress(from);
                    mm.To.Add(new MailAddress(mailAddress));

                    mm.Subject = messageSubject;
                    mm.Body = messageBody;

                    using (var client = new SmtpClient("smtp.mail.ru", 25))
                    {
                        client.DeliveryMethod = SmtpDeliveryMethod.Network;
                        client.UseDefaultCredentials = false;
                        client.Credentials = new NetworkCredential(from, pass);
                        client.EnableSsl = true;
                        mm.IsBodyHtml = true;
                        client.Send(mm);
                    }

                }
                var messegeSucces = String.Format("Email sent to {0}.\nSubject:{1}\nBody:{2}",
                        mailAddress, messageSubject, messageBody);

                return messegeSucces;
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
