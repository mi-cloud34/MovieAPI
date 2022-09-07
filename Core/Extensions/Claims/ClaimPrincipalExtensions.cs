using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extensions.Claims
{
    public static class ClaimPrincipalExtensions
    {
        public static List<String> Claims(this ClaimsPrincipal claimsPrincipal, String claimType)
        {
            return claimsPrincipal.FindAll(claimType).Select(c => c.Value).ToList();
        }

        public static List<String> ClaimRoles(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.Claims(ClaimTypes.Role);
        }
    }
}
