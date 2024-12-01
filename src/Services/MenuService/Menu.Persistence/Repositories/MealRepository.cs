using Menu.Application.Interfaces.Repositories;
using Menu.Domain.Entities;
using Menu.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Persistence.Repositories
{
    public class MealRepository : AsyncRepository<Meal>, IMealRepository
    {
        public MealRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
