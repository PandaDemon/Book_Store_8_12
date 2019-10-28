using System.Threading.Tasks;
using System.Net.Mail;
using System.Net;
using System;
using Store.BusinessLogic.Common.Interfaces;

namespace Store.BusinessLogic.Common
{
	public class EmailSender : IEmailSender
	{
		public async Task SendEmailAsync(string email, string subject, string messageText)
		{
			using (var smtpClient = new SmtpClient())
			{

				using (var message = new MailMessage())
				{
					//var fromAddress = new MailAddress(EmailOptions.BookStoreEmailAdress);

					smtpClient.Host = EmailOptions.GMailHost;
					smtpClient.EnableSsl = true;
					smtpClient.UseDefaultCredentials = false;
					var basicCredential = new NetworkCredential(EmailOptions.BookStoreEmailAdress, EmailOptions.Password);
					smtpClient.Credentials = basicCredential;

					message.From = new MailAddress(EmailOptions.BookStoreEmailAdress);
					message.Subject = subject;

					message.IsBodyHtml = false;
					message.Body = messageText;
					message.To.Add(email);
					smtpClient.Send(message);

				}
			}
		}
	}
}
