using Restaurant.Framework.Abtract;
using System.Net.Mail;

namespace Restaurant.Framework.Factories
{
    public class MailMessageFactory : IMailMessageFactory
    {
        public MailMessage CreateMailMessage(string senderEmailAddress, string senderName, string subject, string recipientAddress, bool isHtmlContent, string mailBody)
        {
            var mail = new MailMessage
            {
                From = new MailAddress(senderEmailAddress, senderName),
                Subject = subject,
                Body = mailBody,
                IsBodyHtml = isHtmlContent
            };
            mail.To.Add(recipientAddress);
            return mail;
        }
    }
}