using System;

namespace Restaurant.IntegrationTests
{
    public class MakeReservationRequest
    {
        public string CustomerName { get; set; }
        public string CustomerEmailAddress { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
    }
}
