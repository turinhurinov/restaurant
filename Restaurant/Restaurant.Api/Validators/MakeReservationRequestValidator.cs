using FluentValidation;
using Restaurant.Api.Model;
using Restaurant.Model;
using System.Globalization;

namespace Restaurant.Api.Validators
{
    public class MakeReservationRequestValidator : AbstractValidator<MakeReservationRequest>
    {
        public MakeReservationRequestValidator()
        {
            RuleFor(x => x.CustomerName)
               .NotNull()
               .NotEmpty()
               .WithMessage(GenerateMessage(ValidationMessages.NotEmpty, PropertyNames.CustomerName));

            RuleFor(x => x.CustomerEmailAddress)
               .NotNull()
               .NotEmpty()
               .WithMessage(GenerateMessage(ValidationMessages.NotEmpty, PropertyNames.CustomerEmailAddress));

            RuleFor(x => x.ReservationDate)
               .NotNull()
               .NotEmpty()
               .WithMessage(GenerateMessage(ValidationMessages.NotEmpty, PropertyNames.ReservationDate));

            RuleFor(x => x.NumberOfGuests)
               .GreaterThan(0)
               .WithMessage(string.Format(CultureInfo.CurrentCulture, ValidationMessages.BeInRange, PropertyNames.NumberOfGuests, 1, 8))
               .LessThan(9)
               .WithMessage(string.Format(CultureInfo.CurrentCulture, ValidationMessages.BeInRange, PropertyNames.NumberOfGuests, 1, 8));
        }

        static string GenerateMessage(string message, string property)
        {
            return string.Format(CultureInfo.CurrentCulture, message, property);
        }
    }
}