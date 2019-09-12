using EASendMail;
using System;


namespace Store.BusinessLogic.Services
{
    public class EmailService
    {
        public static void SendMail(string email, string v, string v1)
        {
            string from = "mpanukov@gmail.com";
            string pass = "mp512055120";
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {
                    From = from,
                    To = "support@emailarchitect.net",
                    Subject = "test email from gmail account",
                    TextBody = "this is a test email sent from c# project with gmail."
                };

                SmtpServer oServer = new SmtpServer("smtp.gmail.com")
                {
                    User = from,
                    Password = pass,
                    Port = 587,
                    ConnectType = SmtpConnectType.ConnectSSLAuto
                };
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
