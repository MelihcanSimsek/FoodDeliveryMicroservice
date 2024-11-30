using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.Extensions
{
    public static class ClaimExtensions
    {
        public static Task AddEmail(this ICollection<Claim> claims,string? email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
            return Task.CompletedTask;
        }

        public static Task AddName(this ICollection<Claim> claims,string fullName)
        {
            claims.Add(new Claim(ClaimTypes.Name, fullName));
            return Task.CompletedTask;
        }

        public static Task AddNameIdentifier(this ICollection<Claim> claims,Guid nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier.ToString()));
            return Task.CompletedTask;
        }

        public static Task AddRoles(this ICollection<Claim> claims,IList<string> roles)
        {
            foreach (var role in roles)
                claims.Add(new Claim(ClaimTypes.Role, role));
            return Task.CompletedTask;
        }
    }
}
