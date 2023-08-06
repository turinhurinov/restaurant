using Moq;
using NUnit.Framework;
using Restaurant.Business.Services;
using Restaurant.Framework.Abtract;
using Restaurant.Model;
using System.Net.Mail;

namespace Restaurant.UnitTests.Business.Services

{
    [TestFixture]
    public class EmailServiceTests
    {
        #region setup

        Mock<ISmtpService> smtpService;
        Mock<IMailMessageFactory> mailMessageFactory;
        Mock<ISettings> settings;

        EmailService service;

        [SetUp]
        public void Initialize()
        {
            smtpService = new Mock<ISmtpService>(MockBehavior.Strict);
            mailMessageFactory = new Mock<IMailMessageFactory>(MockBehavior.Strict);
            settings = new Mock<ISettings>(MockBehavior.Strict);

            service = new EmailService(
                smtpService.Object, 
                mailMessageFactory.Object,
                settings.Object);
        }

        #endregion

        #region teardown

        [TearDown]
        public void VerifyMocks()
        {
            smtpService.VerifyAll();
            mailMessageFactory.VerifyAll();
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
            var senderEmailAddress = "";
            var senderName = "";
            var mailMessage = new MailMessage();
            var mailSent = true;

            settings.Setup(x => x.SupportEmailAddress).Returns(senderEmailAddress);
            settings.Setup(x => x.DefaultMailSenderName).Returns(senderName);
            mailMessageFactory.Setup(x => x.CreateMailMessage(senderEmailAddress, senderName, subject, customerEmailAddress, false, message)).Returns(mailMessage);
            smtpService.Setup(x => x.SendMail(mailMessage)).Returns(mailSent);

            // Act
            service!.SendReservationApprovalEmail(customerEmailAddress, reservation);

            // Assert
            // nothing to assert
        }
    }
}
