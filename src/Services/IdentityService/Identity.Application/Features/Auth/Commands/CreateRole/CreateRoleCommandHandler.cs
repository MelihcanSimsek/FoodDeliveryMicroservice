using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.CreateRole
{
    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommandRequest, Unit>
    {
        private readonly RoleManager<Role> roleManager;

        public CreateRoleCommandHandler(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(CreateRoleCommandRequest request, CancellationToken cancellationToken)
        {
            await roleManager.CreateAsync(new Role()
            {
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Id = Guid.NewGuid(),
                Name = request.RoleName.ToLower(),
                NormalizedName = request.RoleName.ToUpper()
            });

            return Unit.Value;
        }
    }
}
