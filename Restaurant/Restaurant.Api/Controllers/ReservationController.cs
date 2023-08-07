using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Model;
using Restaurant.Business.Abstract;

namespace Restaurant.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : ControllerBase
    {
        #region ctor

        readonly IReservationService reservationService;

        public ReservationController(IReservationService reservationService)
        {
            this.reservationService = reservationService;
        }

        #endregion

        public IActionResult Post(MakeReservationRequest request)
        {
            var makeReservationResult = reservationService.MakeReservation(
                request.CustomerName,
                request.CustomerEmailAddress,
                request.ReservationDate,
                request.NumberOfGuests);

            if (makeReservationResult.IsSuccess)
            {
                return Ok(SuccessResult.Create(makeReservationResult.Message));
            }
            else
            {
                return Problem(
                        makeReservationResult.Message,
                        statusCode: StatusCodes.Status500InternalServerError,
                        title: ServiceResultMessages.ServerError);
            }
        }
    }
}