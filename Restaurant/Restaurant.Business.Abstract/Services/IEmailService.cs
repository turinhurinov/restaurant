using Restaurant.Model;

namespace Restaurant.Business.Abstract
{
    public interface IEmailService
    {
        void SendReservationApprovalEmail(string customerEmailAddress, Reservation reservation);
    }
}