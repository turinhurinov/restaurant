using Restaurant.Model;
using System;

namespace Restaurant.Business.Abstract
{
    public interface IReservationService
    {
        OperationResult MakeReservation(string customerName, string customerEmailAddress, DateTime reservationDate, int numberOfGuests);
    }
}