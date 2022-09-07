using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encyption
{
    public class SigningCreadentialsHelper
    {
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            return new SigningCredentials(
                key: securityKey,
                algorithm:
                SecurityAlgorithms.HmacSha512Signature
                );
        }
    }
}
