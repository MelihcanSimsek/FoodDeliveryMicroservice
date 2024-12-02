using MediatR;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Bases;
using Restaurant.Application.Extensions;
using Restaurant.Application.Features.Restaurants.Rules;
using Restaurant.Application.Interfaces.Mapper;
using Restaurant.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Commands.RestaurantDelete
{

    public class RestaurantDeleteCommandHandler : BaseHandler, IRequestHandler<RestaurantDeleteCommandRequest, Unit>
    {
        private readonly RestaurantRules restaurantRules;

        public RestaurantDeleteCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, RestaurantRules restaurantRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.restaurantRules = restaurantRules;
        }

        public async Task<Unit> Handle(RestaurantDeleteCommandRequest request, CancellationToken cancellationToken)
        {
            Guid userId = httpContextAccessor.HttpContext.User.GetUserId();
            var restaurant = await unitOfWork.GetReadRepository<Restaurant.Domain.Entities.Restaurant>().GetAsync(p => p.UserId == userId && !p.IsDeleted);

            await restaurantRules.ShouldRestaurantExists(restaurant);
            restaurant.IsDeleted = true;
            await unitOfWork.GetWriteRepository<Restaurant.Domain.Entities.Restaurant>().UpdateAsync(restaurant);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
