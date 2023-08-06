using System;

namespace Restaurant.Api.Model
{
    public class MakeReservationRequest
    {
        public string CustomerName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
