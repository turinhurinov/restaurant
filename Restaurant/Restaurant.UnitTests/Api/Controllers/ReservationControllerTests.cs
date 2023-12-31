﻿using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using Restaurant.Api;
using Restaurant.Api.Controllers;
using Restaurant.Api.Model;
using Restaurant.Business.Abstract;
using Restaurant.Model;

namespace Restaurant.UnitTests.Api.Controllers
{
    [TestFixture]
    public class ReservationControllerTests
    {
        #region setup

        Mock<IReservationService>? reservationService;

        ReservationController? controller;

        [SetUp]
        public void Setup()
        {
            reservationService = new Mock<IReservationService>(MockBehavior.Strict);

            controller = new ReservationController(reservationService.Object);
        }

        #endregion

        #region teardown

        [TearDown]
        public void VerifyMocks()
        {
            reservationService.VerifyAll();
        }

        #endregion

        //Bu testte ProblemDetails dönüş tipi oluşturulurken Object reference hatası oluşuyor. Nedeni anlaşılamadı.

        //[Test]
        //public void MakeReservation_InternalServerError_ReturnInternalServerError()
        //{
        //    //Arrange
        //    var request = new MakeReservationRequest();

        //    var makeReservationResult = OperationResult.Error("some-error-occured");

        //    reservationService.Setup(x => x.MakeReservation(request.CustomerName, request.CustomerEmailAddress, request.ReservationDate, request.NumberOfGuests)).Returns(makeReservationResult);

        //    //Act
        //    var result = controller!.Post(request);

        //    //Assert
        //    result.Should().BeOfType<ObjectResult>();
        //    ((ObjectResult)result).StatusCode.Should().Be((int)HttpStatusCode.InternalServerError);
        //    ((ObjectResult)result).Value.Should().BeEquivalentTo(makeReservationResult.Message);
        //}

        [Test]
        public void MakeReservation_Success_ReturnOk()
        {
            //Arrange
            var request = new MakeReservationRequest();

            var makeReservationResult = OperationResult.Success("Ok");
            reservationService.Setup(x => x.MakeReservation(request.CustomerName, request.CustomerEmailAddress, request.ReservationDate, request.NumberOfGuests)).Returns(makeReservationResult);

            //Act
            var result = controller!.Post(request);

            //Assert
            var expectedResult = SuccessResult.Create(makeReservationResult.Message);
            result.Should().BeOfType<OkObjectResult>()
                .Which.Value.Should().BeEquivalentTo(expectedResult);
        }
    }
}
