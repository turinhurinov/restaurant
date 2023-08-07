using System.Net.Mail;

namespace Restaurant.Framework.Abtract
{
	public interface IMailMessageFactory
	{
		MailMessage CreateMailMessage(string senderEmailAddress, string senderName, string subject, string recipientAddress, bool isHtmlContent, string mailBody);
	}
}