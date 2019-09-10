using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.JwtProvider.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Store.BusinessLogic.JwtProvider
{
    public class JwtTokenHandler : IJwtTokenHandler
    {
        private readonly JwtSecurityTokenHandler jwtSecurityTokenHandler;
        private readonly ILogger logger;

        internal JwtTokenHandler(ILogger logger)
        {
            if (jwtSecurityTokenHandler == null)
                jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            this.logger = logger;
        }

        public string WriteToken(JwtSecurityToken jwt)
        {
            return jwtSecurityTokenHandler.WriteToken(jwt);
        }

        public ClaimsPrincipal ValidateToken(string token, TokenValidationParameters tokenValidationParameters)
        {
            try
            {
                var principal = jwtSecurityTokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

                if (!(securityToken is JwtSecurityToken jwtSecurityToken) || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                    throw new SecurityTokenException("Invalid token");

                return principal;
            }
            catch (Exception exeption)
            {
                logger.LogError($"Token validation failed: {exeption.Message}");
                return null;
            }
        }
    }
}
