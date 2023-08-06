using FluentValidation.TestHelper;
using NUnit.Framework;
using Restaurant.Api.Model;
using Restaurant.Api.Validators;
using Restaurant.Model;
using System;
using System.Globalization;

namespace BookingComIntegration.UnitTests.Validation.FluentValidators
{
    [TestFixture]
    [Parallelizable(ParallelScope.Fixtures)]
    public class MakeReservationRequestValidatorTests
    {
        #region members & setup

        MakeReservationRequestValidator? validator;

        [SetUp]
        public void Initialize()
        {
            validator = new MakeReservationRequestValidator();
        }

        #endregion

        static string GenerateMessage(string message, string property)
        {
            return string.Format(CultureInfo.CurrentCulture, message, property);
        }

        #region invalid conditions

        [Test]
        [TestCase("", "")]
        [TestCase(null, null)]
        public void Validate_EmptyValues_HaveError(string customerName, string customerEmailAddress)        {
            //Arrange
            var request = new MakeReservationRequest{
                CustomerName = customerName,
                CustomerEmailAddress = customerEmailAddress,
                ReservationDate = DateTime.MinValue,
                NumberOfGuests = 5
            };

            //Act
            var result = validator.TestValidate(request);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.CustomerName).WithErrorMessage(
                GenerateMessage(ValidationMessages.NotEmpty, PropertyNames.CustomerName)
                );
            result.ShouldHaveValidationErrorFor(x => x.CustomerEmailAddress).WithErrorMessage(
                GenerateMessage(ValidationMessages.NotEmpty, PropertyNames.CustomerEmailAddress)
                );
            result.ShouldHaveValidationErrorFor(x => x.ReservationDate).WithErrorMessage(
                GenerateMessage(ValidationMessages.NotEmpty, PropertyNames.ReservationDate)
                );
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(9)]
        [TestCase(15)]
        public void Validate_NotInRange_HaveError(int numberOfGuests)
        {
            //Arrange
            var request = new MakeReservationRequest
            {
                CustomerName = "test-customer",
                CustomerEmailAddress = "test-customer-email-address",
                ReservationDate = DateTime.Now,
                NumberOfGuests = numberOfGuests
            };

            //Act
            var result = validator.TestValidate(request);

            //Assert
            result.ShouldHaveValidationErrorFor(x => x.NumberOfGuests).WithErrorMessage(
                string.Format(ValidationMessages.BeInRange, PropertyNames.NumberOfGuests, 1, 8)
                );
        }


        #endregion

        #region valid conditions

        [Test]
        [TestCase(1)]
        [TestCase(8)]
        public void Validate_AllPropertiesValid_DoNotHaveError(int numberOfGuests)
        {
            //Arrange
            var request = new MakeReservationRequest
            {
                CustomerName = "test-customer",
                CustomerEmailAddress = "test-customer-email-address",
                ReservationDate = DateTime.Now,
                NumberOfGuests = numberOfGuests
            };

            //Act
            var result = validator.TestValidate(request);

            //Assert
            result.ShouldNotHaveValidationErrorFor(x => x.CustomerName);
            result.ShouldNotHaveValidationErrorFor(x => x.CustomerEmailAddress);
            result.ShouldNotHaveValidationErrorFor(x => x.ReservationDate);
            result.ShouldNotHaveValidationErrorFor(x => x.NumberOfGuests);
        }

        #endregion
    }
}