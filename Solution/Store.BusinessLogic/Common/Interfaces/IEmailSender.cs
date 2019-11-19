using System.Threading.Tasks;

namespace Store.BusinessLogic.Common.Interfaces
{
	public interface IEmailSender
	{
		void SendEmail(string email, string subject, string messageText);
	}
}
