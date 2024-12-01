using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryValidator:AbstractValidator<GetAllRestaurantQueryRequest>
    {
        public GetAllRestaurantQueryValidator()
        {
            RuleFor(p => p.Page).GreaterThan(0);
            RuleFor(p => p.PageSize).GreaterThan(3);
        }
    }
}
