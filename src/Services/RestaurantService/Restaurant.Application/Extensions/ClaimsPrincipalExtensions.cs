using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Application.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static IList<string>? ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal?.Claims(ClaimTypes.Role);
        }

        public static IList<string>? Claims(this ClaimsPrincipal claimsPrincipal,string claimType)
        {
            return claimsPrincipal?.FindAll(claimType)?.Select(x => x.Value).ToList();
        }

        public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return Guid.Parse(claimsPrincipal?.Claims(ClaimTypes.NameIdentifier)?.FirstOrDefault()); ;
        }
    }
}
