using MediatR;
using Microsoft.AspNetCore.Http;
using Restaurant.Application.Bases;
using Restaurant.Application.Interfaces.Mapper;
using Restaurant.Application.Interfaces.UnitOfWorks;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Restaurants.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryHandler : BaseHandler, IRequestHandler<GetAllRestaurantQueryRequest, IList<GetAllRestaurantQueryResponse>>
    {
        public GetAllRestaurantQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, IHttpContextAccessor httpContextAccessor) : base(unitOfWork, mapper, httpContextAccessor)
        {
        }

        public async Task<IList<GetAllRestaurantQueryResponse>> Handle(GetAllRestaurantQueryRequest request, CancellationToken cancellationToken)
        {
            var restaurantList = await unitOfWork.GetReadRepository<Restaurant.Domain.Entities.Restaurant>()
                 .GetAllByPagingAsync(predicate: p => !p.IsDeleted
                 , currentPage: request.Page
                 , pageSize: request.PageSize);

            var response = mapper.Map<GetAllRestaurantQueryResponse, Restaurant.Domain.Entities.Restaurant>(restaurantList);

            return  response;
        }
    }
}
