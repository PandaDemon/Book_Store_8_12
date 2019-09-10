using EASendMail;
using System;


namespace Store.BusinessLogic.Services
{
    public class EmailService
    {
        
        public static void SendMail(string[] args)
        {
            string from = "mpanukov@gmail.com";
            string pass = "mp512055120";
            try
            {
                SmtpMail oMail = new SmtpMail("TryIt")
                {

                    // Your gmail email address
                    From = from,

                    // Set recipient email address
                    To = "support@emailarchitect.net",

                    // Set email subject
                    Subject = "test email from gmail account",

                    // Set email body
                    TextBody = "this is a test email sent from c# project with gmail."
                };

                // Gmail SMTP server address
                SmtpServer oServer = new SmtpServer("smtp.gmail.com")
                {
                    // Gmail user authentication
                    // For example: your email is "gmailid@gmail.com", then the user should be the same
                    User = from,
                    Password = pass,

                    // If you want to use direct SSL 465 port,
                    // please add this line, otherwise TLS will be used.
                    // oServer.Port = 465;

                    // set 587 TLS port;
                    Port = 587,

                    // detect SSL/TLS automatically
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
