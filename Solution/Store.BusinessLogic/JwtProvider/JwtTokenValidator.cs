using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.JwtProvider.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Principal;

namespace Store.BusinessLogic.JwtProvider
{
    public class JwtTokenValidator : IJwtTokenValidator
    {
        public IPrincipal ValidateToken(string authToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = GetValidationParameters();

            IPrincipal principal = tokenHandler.ValidateToken(authToken, validationParameters, out SecurityToken validatedToken);
            return principal;
        }

        public TokenValidationParameters GetValidationParameters()
        {
            return new TokenValidationParameters()
            {
                ValidateLifetime = false,
                ValidateAudience = false,
                ValidateIssuer = false,  
                ValidIssuer = "Sample",
                ValidAudience = "Sample",
                IssuerSigningKey = JwtProvider.GetSymmetricSecurityKey() 
            };
        }
    }
}
