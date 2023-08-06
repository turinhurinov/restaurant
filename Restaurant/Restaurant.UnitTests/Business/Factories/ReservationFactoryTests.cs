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
    public class ReservationFactoryTests
    {
        #region setup

        ReservationFactory factory;

        [SetUp]
        public void Initialize()
        {

            factory = new ReservationFactory();
        }

        #endregion


        [Test]
        public void MakeReservation_AvailableTableNotFound_ReturnErrorResult()
        {
            // Arrange
            string customerName = "test-customer";
            DateTime reservationDate = DateTime.Now;
            int numberOfGuests = 4;
            int tableNumber = 1;

            // Act
            var result = factory!.CreateReservation(customerName, reservationDate, numberOfGuests, tableNumber);

            // Assert
            var expectedResult = new Reservation
            {
                CustomerName = customerName,
                ReservationDate = reservationDate,
                NumberOfGuests = numberOfGuests,
                TableNumber = tableNumber
            };
            result.Should().BeEquivalentTo(expectedResult);
        }
    }
}
