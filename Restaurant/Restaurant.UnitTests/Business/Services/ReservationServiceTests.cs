using Moq;
using NUnit.Framework;
using Restaurant.Business.Services;
using Restaurant.Business.Services.Abstract;
using Restaurant.Data.Repositories.Abstract;

namespace Restaurant.UnitTests.Business.Services

{
    [TestFixture]
    public class ReservationServiceTests
    {
        #region members

        Mock<IReservationRepository> reservationRepository;
        Mock<IEmailService> emailService;

        ReservationService service; 

        [SetUp]
        public void Initialize () 
        {
            reservationRepository = new Mock<IReservationRepository>(MockBehavior.Strict);
            emailService = new Mock<IEmailService>(MockBehavior.Strict);

            service = new ReservationService(
                reservationRepository.Object,
                emailService.Object
                );
        }

        #endregion

        #region teardown

        [TearDown]
        public void VerifyMocks() 
        { 
            reservationRepository.VerifyAll();
            emailService.VerifyAll();
        }

        #endregion

        #region make reservation



        #endregion
    }
}
