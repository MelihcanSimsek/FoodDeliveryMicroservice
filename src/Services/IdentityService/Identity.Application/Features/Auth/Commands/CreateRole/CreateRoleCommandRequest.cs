using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.CreateRole
{
    public class CreateRoleCommandRequest : IRequest<Unit>
    {
        public string RoleName { get; set; }
    }
}
