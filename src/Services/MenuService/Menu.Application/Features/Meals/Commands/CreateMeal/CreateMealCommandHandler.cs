using MediatR;
using Menu.Application.Bases;
using Menu.Application.Extensions;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Commands.CreateMeal
{
    public class CreateMealCommandHandler : BaseHandler, IRequestHandler<CreateMealCommandRequest, Unit>
    {
        private readonly IMealRepository mealRepository;
        public CreateMealCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, IMealRepository mealRepository) : base(httpContextAccessor, mapper)
        {
            this.mealRepository = mealRepository;
        }

        public async Task<Unit> Handle(CreateMealCommandRequest request, CancellationToken cancellationToken)
        {
            Meal meal = mapper.Map<Meal, CreateMealCommandRequest>(request);
            meal.RestaurantId = httpContextAccessor.HttpContext.User.GetUserId();

            await mealRepository.AddAsync(meal);
            return Unit.Value;
        }
    }
}
