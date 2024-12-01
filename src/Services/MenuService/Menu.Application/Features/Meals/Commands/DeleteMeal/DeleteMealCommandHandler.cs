
using MediatR;
using Menu.Application.Bases;
using Menu.Application.Features.Meals.Rules;
using Menu.Application.Interfaces.CustomMapper;
using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace Menu.Application.Features.Meals.Commands.DeleteMeal
{
    public class DeleteMealCommandHandler : BaseHandler, IRequestHandler<DeleteMealCommandRequest, Unit>
    {
        private readonly IMealRepository mealRepository;
        private readonly MealRules mealRules;
        public DeleteMealCommandHandler(IHttpContextAccessor httpContextAccessor, IMapper mapper, IMealRepository mealRepository, MealRules mealRules) : base(httpContextAccessor, mapper)
        {
            this.mealRepository = mealRepository;
            this.mealRules = mealRules;
        }

        public async Task<Unit> Handle(DeleteMealCommandRequest request, CancellationToken cancellationToken)
        {
            Meal? meal = await mealRepository.GetAsync(p => p.Id == request.Id);
            await mealRules.ShouldMealExists(meal);

            meal.IsDeleted = true;
            await mealRepository.UpdateAsync(meal);

            return Unit.Value;
        }
    }
}
