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
        readonly ITableService tableService;
        readonly IEmailService emailService;

        public ReservationService(
            IReservationRepository reservationRepository, 
            ITableService tableService,
            IEmailService emailService)
        {
            this.reservationRepository = reservationRepository;
            this.tableService = tableService;
            this.emailService = emailService;
        }

        #endregion

        public OperationResult MakeReservation(string customerName, string customerEmailAddress, DateTime date, int guests)
        {
            var tables = GetAvailableTables(date, guests);
            if (!AvailableTableExists(tables))
            {
                return OperationResult.Error("Üzgünüz, uygun masa bulunamadı.");
            }

            var reservation = CreateReservation(customerName, date, guests, tables);
            SaveReservation(reservation);
            SendReservationEmail(customerEmailAddress, reservation);

            return OperationResult.Success("Rezervasyon başarıyla yapıldı.");
        }

        //TODO: Create through factory
        static Reservation CreateReservation(string customerName, DateTime date, int guests, List<Table> tables)
        {
            var table = tables[0];
            return new Reservation
            {
                CustomerName = customerName,
                ReservationDate = date,
                NumberOfGuests = guests,
                TableNumber = table.Number
            };
        }

        static bool AvailableTableExists(List<Table> tables)
        {
            return tables != null && tables.Count > 0;
        }

        List<Table> GetAvailableTables(DateTime reservationDate, int numberOfGuests)
        {
            return tableService.GetAvailableTables(reservationDate, numberOfGuests);
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