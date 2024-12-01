using MediatR;
using Menu.Application.Bases;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Queries.GetAllMeal
{
    public class GetAllMealQueryHandler : BaseHandler, IRequestHandler<GetAllMealQueryRequest, IList<GetAllMealQueryResponse>>
    {
        private readonly IMealRepository mealRepository;
        public GetAllMealQueryHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, IMealRepository mealRepository) : base(httpContextAccessor, mapper)
        {
            this.mealRepository = mealRepository;
        }

        public async Task<IList<GetAllMealQueryResponse>> Handle(GetAllMealQueryRequest request, CancellationToken cancellationToken)
        {
            IList<Meal> mealList = await mealRepository.GetAllByPagingAsync(predicate: p => p.RestaurantId == request.RestaurantId, currentPage: request.Page, pageSize: request.Size);
            var response = mapper.Map<GetAllMealQueryResponse, Meal>(mealList);
            return response;
        }
    }
}
