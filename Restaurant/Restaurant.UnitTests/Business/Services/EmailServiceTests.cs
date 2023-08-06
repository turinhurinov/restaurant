using Moq;
using NUnit.Framework;
using Restaurant.Business.Services;
using Restaurant.Framework;
using Restaurant.Model;

namespace Restaurant.UnitTests.Business.Services

{
    [TestFixture]
    public class EmailServiceTests
    {
        #region setup

        Mock<ISmtpService> smtpService;

        EmailService service;

        [SetUp]
        public void Initialize()
        {
            smtpService = new Mock<ISmtpService>(MockBehavior.Strict);

            service = new EmailService(smtpService.Object);
        }

        #endregion

        #region teardown

        [TearDown]
        public void VerifyMocks()
        {
            smtpService.VerifyAll();
        }

        #endregion

        [Test]
        public void SendReservationApprovalEmail_NoCondition_SendEmail()
        {
            // Arrange
            string customerEmailAddress = "test-email-address";
            var reservation = new Reservation();

            string subject = "Rezervasyon Onayı";
            var message = $"Sayın {reservation.CustomerName}, rezervasyonunuz başarıyla alındı. Masa No: {reservation.TableNumber}, Tarih: {reservation.ReservationDate}, Kişi Sayısı: {reservation.NumberOfGuests}";


            smtpService.Setup(x => x.SendEmail(customerEmailAddress, subject, message));

            // Act
            service!.SendReservationApprovalEmail(customerEmailAddress, reservation);

            // Assert
            // nothing to assert
        }
    }
}
