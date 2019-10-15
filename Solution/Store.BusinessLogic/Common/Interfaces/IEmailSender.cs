using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.Interfaces
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string messageText);
	}
}
