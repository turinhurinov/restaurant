namespace Restaurant.Business.Services.Abstract
{
    public interface IEmailService
    {
        void SendEmail(string recipient, string subject, string message);
    }
}