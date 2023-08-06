using Restaurant.Model;
using System;

namespace Restaurant.Business.Services.Abstract
{
    public interface IReservationService
    {
        OperationResult MakeReservation(string customerName, string customerEmailAddress, DateTime reservationDate, int numberOfGuests);
    }
}