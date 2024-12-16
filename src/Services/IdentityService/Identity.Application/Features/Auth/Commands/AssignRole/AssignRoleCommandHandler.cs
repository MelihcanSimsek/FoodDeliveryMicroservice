using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.AssignRole
{
    public class AssignRoleCommandHandler : IRequestHandler<AssignRoleCommandRequest, Unit>
    {
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public AssignRoleCommandHandler(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(AssignRoleCommandRequest request, CancellationToken cancellationToken)
        {
            User? user = await userManager.FindByIdAsync(request.UserId.ToString());
            Role? role = await roleManager.FindByIdAsync(request.RoleId.ToString());

            await userManager.AddToRoleAsync(user, role.Name);

            return Unit.Value;
        }
    }
}
