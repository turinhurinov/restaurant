using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Api.Model;
using Restaurant.Api.Model.Messages;
using Restaurant.Business.Services.Abstract;

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
                return Ok(makeReservationResult.Message);
            }
            else
            {
                return Problem(
                        detail: makeReservationResult.Message,
                        statusCode: StatusCodes.Status500InternalServerError,
                        title: ServiceResultMessages.ServerError);
            }
        }
    }
}