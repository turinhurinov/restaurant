using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ROPNG.Host
{
    using System;

    public class ReservationManager
    {
        public void MakeReservation(string name, DateTime date, int guests)
        {
            var tables = GetTables(date, guests);
            if (tables == null || tables.Count == 0)
            {
                Console.WriteLine("Üzgünüz, uygun masa bulunamadı.");
                return;
            }

            var table = tables[0];
            var reservation = new Reservation
            {
                CustomerName = name,
                ReservationDate = date,
                NumberOfGuests = guests,
                TableNumber = table.Number
            };

            SaveReservation(reservation);

            // Rezervasyon onay e-postası gönderme
            var email = $"Sayın {name}, rezervasyonunuz başarıyla alındı. Masa No: {table.Number}, Tarih: {date}, Kişi Sayısı: {guests}";
            SendEmail(name, "Rezervasyon Onayı", email);

            Console.WriteLine("Rezervasyon başarıyla yapıldı.");
        }

        public List<Table> GetTables(DateTime date, int guests)
        {
            // Burada uygun masaların listesini getirme işlemi yapılır.
            // ...
            return new List<Table>();
        }

        public void SaveReservation(Reservation reservation)
        {
            // Rezervasyon kaydetme işlemi
            // ...
        }

        public void SendEmail(string recipient, string subject, string message)
        {
            // E-posta gönderme işlemi
            // ...
        }
    }

    public class Reservation
    {
        public string CustomerName { get; set; }
        public DateTime ReservationDate { get; set; }
        public int NumberOfGuests { get; set; }
        public int TableNumber { get; set; }
    }

    public class Table
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
    }
}