using System;

namespace Restaurant.Business.Services.Abstract
{
    public interface IReservationService
    {
        void MakeReservation(string customerName, string customerEmailAddress, DateTime date, int guests);
    }
}