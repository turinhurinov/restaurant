using FluentAssertions;
using Moq;
using NUnit.Framework;
using Restaurant.Business.Factories.Abstract;
using Restaurant.Business.Services;
using Restaurant.Business.Services.Abstract;
using Restaurant.Data.Repositories.Abstract;
using Restaurant.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.UnitTests.Business.Services

{
    [TestFixture]
    public class ReservationServiceTests
    {
        #region members

        Mock<IReservationRepository> reservationRepository;
        Mock<ITableService> tableService;
        Mock<IReservationFactory> reservationFactory;
        Mock<IEmailService> emailService;

        ReservationService service;

        [SetUp]
        public void Initialize()
        {
            reservationRepository = new Mock<IReservationRepository>(MockBehavior.Strict);
            tableService = new Mock<ITableService>(MockBehavior.Strict);
            reservationFactory = new Mock<IReservationFactory>(MockBehavior.Strict);
            emailService = new Mock<IEmailService>(MockBehavior.Strict);

            service = new ReservationService(
                reservationRepository.Object,
                tableService.Object,
                reservationFactory.Object,
                emailService.Object
                );
        }

        #endregion

        #region teardown

        [TearDown]
        public void VerifyMocks()
        {
            reservationRepository.VerifyAll();
            tableService.VerifyAll();
            reservationFactory.VerifyAll();
            emailService.VerifyAll();
        }

        #endregion

        #region make reservation

        [Test]
        public void MakeReservation_AvailableTableNotFound_ReturnErrorResult()
        {
            // Arrange
            string customerName = "test-customer";
            string customerEmailAddress = "test-email-address";
            DateTime reservationDate = DateTime.Now;
            int numberOfGuests = 4;
            
            var tables = CreateEmptyTableList();

            tableService.Setup(x => x.GetAvailableTables(reservationDate, numberOfGuests)).Returns(tables);

            // Act
            var result = service!.MakeReservation(customerName, customerEmailAddress, reservationDate, numberOfGuests);

            // Assert
            var expectedResult = OperationResult.Error("Üzgünüz, uygun masa bulunamadı.");
            result.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public void MakeReservation_AvailableTableFound_SaveReservationSendEmailAndReturnErrorResult()
        {
            // Arrange
            string customerName = "test-customer";
            string customerEmailAddress = "test-email-address";
            DateTime reservationDate = DateTime.Now;
            int numberOfGuests = 4;

            var tables = CreateValidTableList();
            var reservation = new Reservation();

            tableService.Setup(x => x.GetAvailableTables(reservationDate, numberOfGuests)).Returns(tables);
            reservationFactory.Setup(x => x.CreateReservation(customerName, reservationDate, numberOfGuests, tables[0].Number)).Returns(reservation);
            reservationRepository.Setup(x => x.SaveReservation(reservation));
            emailService.Setup(x => x.SendEmail(It.IsAny<string>(), "Rezervasyon Onayı", It.IsAny<string>()));

            // Act
            var result = service!.MakeReservation(customerName, customerEmailAddress, reservationDate, numberOfGuests);

            // Assert
            var expectedResult = OperationResult.Success("Rezervasyon başarıyla yapıldı.");
            result.Should().BeEquivalentTo(expectedResult);
        }

        #endregion

        #region setup helpers
        static List<Table> CreateEmptyTableList()
        {
            return new List<Table>();
        }

        static List<Table> CreateValidTableList()
        {
            return new List<Table> {
                new Table{
                    Number = 1,
                    Capacity = 4
                }
            };
        }
        #endregion
    }
}
