using Restaurant.Model;
using System;

namespace Restaurant.Business.Factories.Abstract
{
    public interface IReservationFactory
    {
        Reservation CreateReservation(string customerName, DateTime reservationDate, int numberOfGuests, int tableNumber);
    }
}