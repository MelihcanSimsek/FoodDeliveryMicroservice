using MediatR;
using Restaurant.Application.Interfaces.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Features.Branches.Commands.BranchDelete
{
    public class BranchDeleteCommandRequest : IRequest<Unit>,ISecuredRequest
    {
        public Guid Id { get; set; }
        public string[] Roles => ["restaurantadmin"];
    }
}
