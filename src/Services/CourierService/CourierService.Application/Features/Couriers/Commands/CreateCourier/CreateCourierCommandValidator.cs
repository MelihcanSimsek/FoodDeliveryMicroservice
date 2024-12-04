using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Commands.CreateCourier
{
    public class CreateCourierCommandValidator : AbstractValidator<CreateCourierCommandRequest>
    {
        public CreateCourierCommandValidator()
        {
            RuleFor(p => p.IdentityNumber).NotEmpty().MinimumLength(11).MaximumLength(11);
            RuleFor(p => p.PhoneNumber).NotEmpty().MinimumLength(13).MaximumLength(13);
            RuleFor(p => p.BusinessEmail).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(30);
            RuleFor(p => p.City).NotEmpty();
            RuleFor(p => p.Country).NotEmpty();
            RuleFor(p => p.District).NotEmpty();
            RuleFor(P => P.PlateNumber).NotEmpty().MinimumLength(6);
            RuleFor(p => p.UserId).NotEmpty();
        }
    }
}
