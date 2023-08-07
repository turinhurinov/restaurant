using Restaurant.Model;

namespace Restaurant.Data.Abstract
{
    public interface IReservationRepository
    {
        void SaveReservation(Reservation reservation);
    }
}
