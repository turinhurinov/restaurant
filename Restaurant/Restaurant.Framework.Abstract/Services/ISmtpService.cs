using System.Net.Mail;

namespace Restaurant.Framework.Abtract
{
    public interface ISmtpService
    {
        bool SendMail(MailMessage mail);
    }
}
