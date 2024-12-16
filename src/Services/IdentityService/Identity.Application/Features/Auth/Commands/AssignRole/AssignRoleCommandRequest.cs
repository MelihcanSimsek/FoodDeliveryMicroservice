using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.AssignRole
{
    public class AssignRoleCommandRequest : IRequest<Unit>
    {
        public Guid UserId { get; set; }
        public Guid RoleId { get; set; }
    }
}
