using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Store.BusinessLogic.JwtProvider.Interfaces
{
    public interface IJwtTokenValidator
    {

        IPrincipal ValidateToken(string authToken);
        TokenValidationParameters GetValidationParameters();
    }
}
