using Restaurant.Business.Factories.Abstract;
using Restaurant.Business.Services.Abstract;
using Restaurant.Data.Repositories.Abstract;
using Restaurant.Model;
using Restaurant.Model.Messages;
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

        public OperationResult MakeReservation(string customerName, string customerEmailAddress, DateTime reservationDate, int numberOfGuests)
        {
            var tables = GetAvailableTables(reservationDate, numberOfGuests);
            
            if (!AvailableTableExists(tables))
            {
                return OperationResult.Error(UserMessages.AvailableTableForReservationNotFound);
            }

            var reservation = CreateReservation(customerName, reservationDate, numberOfGuests, tables);
            SaveReservation(reservation);
            SendReservationEmail(customerEmailAddress, reservation);
            return OperationResult.Success(UserMessages.ReservationSavedSuccessfully);
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

        void SendReservationEmail(string customerEmailAddress, Reservation reservation)
        {
            emailService.SendReservationApprovalEmail(customerEmailAddress, reservation);
        }

        #endregion
    }
}