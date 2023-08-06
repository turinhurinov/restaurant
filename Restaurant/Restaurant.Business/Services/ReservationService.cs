using Restaurant.Business.Factories.Abstract;
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
        readonly IReservationFactory reservationFactory;
        readonly IEmailService emailService;

        public ReservationService(
            IReservationRepository reservationRepository, 
            ITableService tableService,
            IReservationFactory reservationFactory,
            IEmailService emailService)
        {
            this.reservationRepository = reservationRepository;
            this.tableService = tableService;
            this.reservationFactory = reservationFactory;
            this.emailService = emailService;
        }

        #endregion

        #region make reservation

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

        List<Table> GetAvailableTables(DateTime reservationDate, int numberOfGuests)
        {
            return tableService.GetAvailableTables(reservationDate, numberOfGuests);
        }

        static bool AvailableTableExists(List<Table> tables)
        {
            return tables != null && tables.Count > 0;
        }

        Reservation CreateReservation(string customerName, DateTime reservationDate, int numberOfGuests, List<Table> tables)
        {
            var availableTableNumber = tables[0].Number;
            return reservationFactory.CreateReservation(customerName, reservationDate, numberOfGuests, availableTableNumber);
        }


        void SaveReservation(Reservation reservation)
        {
            reservationRepository.SaveReservation(reservation);
        }

        void SendReservationEmail(string recipient, Reservation reservation)
        {
            var message = $"Sayın {reservation.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {reservation.TableNumber}, Tarih: {reservation.ReservationDate}, Kişi Sayısı: {reservation.NumberOfGuests}";
            emailService.SendEmail(recipient, "Rezervasyon Onayı", message);
        }

        #endregion
    }
}