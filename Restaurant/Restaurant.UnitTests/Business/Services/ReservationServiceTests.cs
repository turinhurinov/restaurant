using FluentAssertions;
using Moq;
using NUnit.Framework;
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
        Mock<IEmailService> emailService;
        Mock<ITableService> tableService;

        ReservationService service; 

        [SetUp]
        public void Initialize () 
        {
            reservationRepository = new Mock<IReservationRepository>(MockBehavior.Strict);
            emailService = new Mock<IEmailService>(MockBehavior.Strict);
            tableService = new Mock<ITableService>(MockBehavior.Strict);

            service = new ReservationService(
                reservationRepository.Object,
                tableService.Object,
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

            var tables = new List<Table>();

            tableService.Setup(x => x.GetAvailableTables(reservationDate, numberOfGuests)).Returns(tables);

            // Act
            var result = service!.MakeReservation(customerName, customerEmailAddress, reservationDate, numberOfGuests);

            // Assert
            var expectedResult = OperationResult.Error("Üzgünüz, uygun masa bulunamadı.");
            result.Should().BeEquivalentTo(expectedResult);
        }


        #endregion
    }
}
