using MediatR;
using Restaurant.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Commands.BranchCreate
{
    public class BranchCreateCommandRequest : IRequest<Unit>, ISecuredRequest
    {
        public Guid RestaurantId { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string[] Roles => ["delivery.owner.restaurant"];
    }
}
