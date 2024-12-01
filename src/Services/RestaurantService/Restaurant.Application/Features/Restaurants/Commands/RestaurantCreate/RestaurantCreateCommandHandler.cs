using MediatR;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Bases;
using Restaurant.Application.Features.Restaurants.Rules;
using Restaurant.Application.Interfaces.Mapper;
using Restaurant.Application.Interfaces.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Commands.RestaurantCreate
{
    public class RestaurantCreateCommandHandler : BaseHandler,IRequestHandler<RestaurantCreateCommandRequest, Unit>
    {
        private readonly RestaurantRules restaurantRules;
        public RestaurantCreateCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor, RestaurantRules restaurantRules) : base(unitOfWork, mapper, httpContextAccessor)
        {
            this.restaurantRules = restaurantRules;
        }

        public async Task<Unit> Handle(RestaurantCreateCommandRequest request, CancellationToken cancellationToken)
        {
            var checkRestaurant = await unitOfWork.GetReadRepository<Restaurant.Domain.Entities.Restaurant>().GetAsync(p => p.Name == request.Name);

            await restaurantRules.ShouldRestaurantNameCanNotBeDuplicated(checkRestaurant);

            var restaurant = mapper.Map<Restaurant.Domain.Entities.Restaurant, RestaurantCreateCommandRequest>(request);

            await unitOfWork.GetWriteRepository<Restaurant.Domain.Entities.Restaurant>().AddAsync(restaurant);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}
