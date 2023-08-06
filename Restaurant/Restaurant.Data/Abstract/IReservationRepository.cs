using Restaurant.Model;

namespace Restaurant.Data.Repositories.Abstract
{
    public interface IReservationRepository
    {
        void SaveReservation(Reservation reservation);
    }
}
