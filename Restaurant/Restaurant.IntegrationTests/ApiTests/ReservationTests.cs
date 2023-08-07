using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NUnit.Framework;
using Restaurant.Model.Messages;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Restaurant.IntegrationTests.ApiTests
{
    [TestFixture]
    public class ReservationTests : BaseSystemTestFixture
    {
        [Test]
        [TestCase("", "", 1)]
        [TestCase(null, null, 1)]
        [TestCase("customer-name", null, 1)]
        [TestCase("customer-name", "", 1)]
        [TestCase(null, "customer-email-address", 1)]
        [TestCase("", "customer-email-address", 1)]
        [TestCase(null, "test@example.org", 1)]
        [TestCase("", "test@example.org", 1)]
        [TestCase("customer-name", "test@example.org", -1)]
        [TestCase("customer-name", "test@example.org", 0)]
        [TestCase("customer-name", "test@example.org", 9)]
        [TestCase("customer-name", "test@example.org", 15)]
        public async Task MakeReservation_InvalidParameters_ReturnBadRequest(
           string customerName,
           string customerEmailAddress,
           int numberOfGuests)
        {
            // Arrange
            var request = new MakeReservationRequest
            {
                CustomerName = customerName,
                CustomerEmailAddress = customerEmailAddress,
                ReservationDate = DateTime.Now,
                NumberOfGuests = numberOfGuests
            };

            // Act
            var result = await SendPostRequest(ApiUrls.MakeReservation, request);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [Test]
        public async Task MakeReservation_AvailableTableNotFound_ReturnInternalServerError()
        {
            // Arrange
            var request = new MakeReservationRequest
            {
                CustomerName = "customer-name",
                CustomerEmailAddress = "test@example.org",
                ReservationDate = DateTime.Now,
                NumberOfGuests = 5
            };

            // Act
            var result = await SendPostRequest(ApiUrls.MakeReservation, request);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.InternalServerError);
            var problemDetails = JsonConvert.DeserializeObject<ProblemDetails>(result.ResponseContent.ToString());
            problemDetails.Detail.Should().Be(UserMessages.AvailableTableForReservationNotFound);
        }

        [Test]
        public async Task MakeReservation_AvailableTableFound_ReturnSuccess()
        {
            // Arrange
            var request = new MakeReservationRequest
            {
                CustomerName = "customer-name",
                CustomerEmailAddress = "test@example.org",
                ReservationDate = DateTime.Now,
                NumberOfGuests = 3
            };

            // Act
            var result = await SendPostRequest(ApiUrls.MakeReservation, request);

            // Assert
            result.StatusCode.Should().Be(HttpStatusCode.OK);
        }
    }
}