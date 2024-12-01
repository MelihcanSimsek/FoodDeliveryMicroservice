using MediatR;
using Menu.Application.Bases;
using Menu.Application.Features.Meals.Rules;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Commands.UpdateMeal
{
    public class UpdateMealCommandHandler : BaseHandler, IRequestHandler<UpdateMealCommandRequest, Unit>
    {
        private readonly IMealRepository mealRepository;
        private readonly MealRules mealRules;
        public UpdateMealCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, MealRules mealRules, IMealRepository mealRepository) : base(httpContextAccessor, mapper)
        {
            this.mealRules = mealRules;
            this.mealRepository = mealRepository;
        }

        public async Task<Unit> Handle(UpdateMealCommandRequest request, CancellationToken cancellationToken)
        {
            Meal? meal = await mealRepository.GetAsync(p => p.Id == request.Id);
            await mealRules.ShouldMealExists(meal);

            meal = mapper.Map<Meal, UpdateMealCommandRequest>(request);
            await mealRepository.UpdateAsync(meal);

            return Unit.Value;
        }
    }
}
