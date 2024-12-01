using MediatR;
using Restaurant.Application.Interfaces.Authorization;


namespace Restaurant.Application.Features.Restaurants.Queries.GetAllRestaurant
{
    public class GetAllRestaurantQueryRequest:IRequest<IList<GetAllRestaurantQueryResponse>>,ISecuredRequest
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public string[] Roles => ["user"];
    }
}
