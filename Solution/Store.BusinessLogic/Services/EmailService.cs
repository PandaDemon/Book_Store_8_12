using EASendMail;
using System;


namespace Store.BusinessLogic.Services
{
    public class EmailService
    {
        //public static string SendMail(string mailAddress, string messageSubject, string messageBody)
        //{
        //    string from = "mpanukov@gmail.com";
        //    string pass = "mp512055120";
        //    try
        //    {
        //        using (var mailMessage = new MailMessage())
        //        {
        //            mailMessage.From = new MailAddress(from);
        //            mailMessage.To.Add(new MailAddress(mailAddress));

        //            mailMessage.Subject = messageSubject;
        //            mailMessage.Body = messageBody;

        //            using (var client = new SmtpClient("smtp.gmail.com", 25))
        //            {
        //                client.DeliveryMethod = SmtpDeliveryMethod.Network;
        //                client.UseDefaultCredentials = false;
        //                client.Credentials = new NetworkCredential(from, pass);
        //                client.EnableSsl = true;

        //                mailMessage.IsBodyHtml = true;

        //                client.Send(mailMessage);
        //            }

        //        }
        //        var messegeSuccess = $"Email sent to {mailAddress}.\nSubject:{messageSubject}\nBody:{messageBody}";

        //        return messegeSuccess;
        //    }
        //    catch (Exception exception)
        //    {
        //        var message = String.Format("Cant send mail. Subject: {0}. To: {1}. Body: {2}.",
        //            messageSubject, mailAddress, messageBody);

        //        throw new MailException(message, exception);
        //    }
        //}
        public static void SendMail(string[] args)
        {
            string from = "mpanukov@gmail.com";
            string pass = "mp512055120";
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt");

                // Your gmail email address
                oMail.From = from;

                // Set recipient email address
                oMail.To = "support@emailarchitect.net";

                // Set email subject
                oMail.Subject = "test email from gmail account";

                // Set email body
                oMail.TextBody = "this is a test email sent from c# project with gmail.";

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com");

                // Gmail user authentication
                // For example: your email is "gmailid@gmail.com", then the user should be the same
                oServer.User = from;
                oServer.Password = pass;

                // If you want to use direct SSL 465 port,
                // please add this line, otherwise TLS will be used.
                // oServer.Port = 465;

                // set 587 TLS port;
                oServer.Port = 587;

                // detect SSL/TLS automatically
                oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

                Console.WriteLine("start to send email over SSL ...");

                SmtpClient oSmtp = new SmtpClient();
                oSmtp.SendMail(oServer, oMail);

                Console.WriteLine("email was sent successfully!");
            }
            catch (Exception exception)
            {
                Console.WriteLine("failed to send email with the following error:");
                Console.WriteLine(exception.Message);
            }
        }
    }
}
