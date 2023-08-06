namespace Restaurant.Framework
{
    public interface ISmtpService
    {
        void SendEmail(string recipient, string subject, string message);
    }
}
