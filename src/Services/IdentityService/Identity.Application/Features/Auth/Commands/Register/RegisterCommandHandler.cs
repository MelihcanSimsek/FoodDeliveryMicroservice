using Identity.Application.Features.Auth.Rules;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExistsWhenRegistered(await userManager.FindByEmailAsync(request.Email));

            User user = new()
            {
                FullName = request.FullName,
                UserName = request.Email,
                Email = request.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
            };

            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if (result.Succeeded)
                if (!await roleManager.RoleExistsAsync("user"))
                    await roleManager.CreateAsync(new Role()
                    {
                        ConcurrencyStamp = Guid.NewGuid().ToString(),
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER"
                    });

            await userManager.AddToRoleAsync(user, "user");

            return Unit.Value;
        }
    }
}
