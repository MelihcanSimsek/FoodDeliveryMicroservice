using Menu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu.Application.Interfaces.Repositories
{
    public interface IMealRepository : IAsyncRepository<Meal>
    {
    }
}
