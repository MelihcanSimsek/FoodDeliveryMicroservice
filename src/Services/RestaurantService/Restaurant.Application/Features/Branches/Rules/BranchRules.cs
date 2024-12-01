using Restaurant.Application.Bases;
using Restaurant.Application.Features.Branches.Exceptions;
using Restaurant.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Rules
{
    public class BranchRules : BaseRules
    {
        public async Task ShouldRestaurantExists(Restaurant.Domain.Entities.Restaurant? restaurant)
        {
            if (restaurant is null) throw new RestaurantNotFoundException();
        }

        public async Task ShouldBranchExists(Branch? branch)
        {
            if (branch is null) throw new BranchNotFoundException();
        }

        public async Task ShouldBranchCanNotBeDuplicated(Branch? branch)
        {
            if (branch is not null) throw new BranchLocationCanNotBeDuplicatedException();
        }
    }
}
