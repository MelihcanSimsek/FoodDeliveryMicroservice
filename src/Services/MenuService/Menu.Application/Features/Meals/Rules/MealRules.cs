using Menu.Application.Bases;
using Menu.Application.Features.Meals.Exceptions;
using Menu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Features.Meals.Rules
{
    public class MealRules : BaseRules
    {
        public async Task ShouldMealExists(Meal? meal)
        {
            if (meal is null) throw new MealNotFoundException();
        }
    }
}
