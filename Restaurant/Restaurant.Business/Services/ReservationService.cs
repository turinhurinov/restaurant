using Restaurant.Business.Services.Abstract;
using Restaurant.Data.Repositories.Abstract;
using Restaurant.Model;
using System;
using System.Collections.Generic;

namespace Restaurant.Business.Services
{

    public class ReservationService : IReservationService
    {

        #region ctor

        readonly IReservationRepository reservationRepository;
        readonly IEmailService emailService;

        public ReservationService(IReservationRepository reservationRepository, IEmailService emailService)
        {
            this.reservationRepository = reservationRepository;
            this.emailService = emailService;
        }

        #endregion

        public void MakeReservation(string customerName, string customerEmailAddress, DateTime date, int guests)
        {
            //TODO: validate request
            var tables = GetAvailableTables(date, guests);
            if (!AvailableTableExists(tables))
            {
                Console.WriteLine("Üzgünüz, uygun masa bulunamadı.");
                return;
            }

            //TODO: Create through factory
            var table = tables[0];
            var reservation = new Reservation
            {
                CustomerName = customerName,
                ReservationDate = date,
                NumberOfGuests = guests,
                TableNumber = table.Number
            };

            SaveReservation(reservation);
            SendReservationEmail(customerEmailAddress, reservation);

            Console.WriteLine("Rezervasyon başarıyla yapıldı.");
        }

        static bool AvailableTableExists(List<Table> tables)
        {
            return tables != null && tables.Count > 0;
        }

        List<Table> GetAvailableTables(DateTime date, int numberOfGuests)
        {
            //TODO: get from TableService
            return new List<Table>();
        }

        void SaveReservation(Reservation reservation)
        {
            reservationRepository.SaveReservation(reservation);
        }

        void SendReservationEmail(string recipient, Reservation reservation)
        {
            var message = $"Sayın {reservation.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {reservation.TableNumber}, Tarih: {reservation.ReservationDate}, Kişi Sayısı: {reservation.NumberOfGuests}";
            emailService.SendEmai(recipient, "Rezervasyon Onayı", message);
        }
    }
}