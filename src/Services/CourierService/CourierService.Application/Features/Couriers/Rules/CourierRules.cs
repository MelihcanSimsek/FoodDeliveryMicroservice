using CourierService.Application.Bases;
using CourierService.Application.Features.Couriers.Exceptions;
using CourierService.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierService.Application.Features.Couriers.Rules
{
    public class CourierRules : BaseRules
    {
        public async Task ShouldCourierNotExists(Courier? courier)
        {
            if (courier is not null) throw new CourierAlreadyExistsException();
        }

        public async Task ShouldCourierExists(Courier? courier)
        {
            if (courier is null) throw new CourierNotExistsException(); 
        }
    }
}
