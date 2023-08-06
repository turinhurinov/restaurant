using Restaurant.Model;

namespace Restaurant.Business.Services.Abstract
{
    public interface IEmailService
    {
        void SendReservationApprovalEmail(string customerEmailAddress, Reservation reservation);
    }
}