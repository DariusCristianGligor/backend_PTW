using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public interface IJwtService
    {
        public string Generate(Guid id);

        public JwtSecurityToken Verify(string jwt);

    }
}
