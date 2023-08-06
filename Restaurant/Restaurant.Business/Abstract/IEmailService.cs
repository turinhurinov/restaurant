namespace Restaurant.Business.Services.Abstract
{
    public interface IEmailService
    {
        void SendEmai(string recipient, string subject, string message);
    }
}