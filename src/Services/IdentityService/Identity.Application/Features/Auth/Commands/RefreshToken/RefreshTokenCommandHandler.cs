using Identity.Application.Features.Auth.Rules;
using Identity.Application.Interfaces.Tokens;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Features.Auth.Commands.RefreshToken
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommandRequest, RefreshTokenCommandResponse>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly ITokenService tokenService;
        private readonly IConfiguration configuration;

        public RefreshTokenCommandHandler(AuthRules authRules, UserManager<User> userManager,
            ITokenService tokenService, IConfiguration configuration)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.tokenService = tokenService;
            this.configuration = configuration;
        }

        public async Task<RefreshTokenCommandResponse> Handle(RefreshTokenCommandRequest request, CancellationToken cancellationToken)
        {
            ClaimsPrincipal? principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken);
            string? email = principal.FindFirstValue(ClaimTypes.Email);

            User? user = await userManager.FindByEmailAsync(email);
            IList<string> roles = await userManager.GetRolesAsync(user);

            await authRules.ShouldUserRefreshTokenNotBeExpired(user.RefreshTokenExpiryDate);

            JwtSecurityToken _token = await tokenService.CreateToken(user, roles);
            string refreshToken = tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            await userManager.UpdateAsync(user);

            return new()
            {
                RefreshToken = refreshToken,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(_token)
            };
        }
    }
}
