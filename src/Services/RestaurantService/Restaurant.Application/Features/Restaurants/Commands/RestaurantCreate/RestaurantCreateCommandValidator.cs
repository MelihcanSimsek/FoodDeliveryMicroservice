using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Commands.RestaurantCreate
{
    public class RestaurantCreateCommandValidator:AbstractValidator<RestaurantCreateCommandRequest>
    {
        public RestaurantCreateCommandValidator()
        {
            RuleFor(p => p.Name).NotEmpty().MinimumLength(10).MaximumLength(50);
            RuleFor(p => p.Country).NotEmpty().MinimumLength(3);
            RuleFor(p => p.EmailContact).NotEmpty().EmailAddress().MinimumLength(8).MaximumLength(50);
            RuleFor(p => p.PhoneContact).NotEmpty().MinimumLength(13).MaximumLength(13);
        }
    }
}
