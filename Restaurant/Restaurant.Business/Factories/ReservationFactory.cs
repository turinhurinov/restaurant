using Restaurant.Business.Abstract;
using Restaurant.Model;
using System;

namespace Restaurant.Business.Services
{

    public class ReservationFactory : IReservationFactory
    {
        public Reservation CreateReservation(string customerName, DateTime reservationDate, int numberOfGuests, int tableNumber)
        {
            return new Reservation
            {
                CustomerName = customerName,
                ReservationDate = reservationDate,
                NumberOfGuests = numberOfGuests,
                TableNumber = tableNumber
            };
        }
    }
}