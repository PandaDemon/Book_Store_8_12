using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.Models.User;
using System;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Store.BusinessLogic.JwtProvider
{
    public class JwtProvider
    {
        public const string ISSUER = "Book_Store_14_08";
        public const string AUDIENCE = "http://localhost:44350/";
        const string KEY = "o8!s-l&9u4q83-78mnk2D9";
        public const int LIFETIME = 10;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }

        public static SecurityTokenDescriptor GenerateSecurityTokenDescriptor(UserModel user)
        {
            IdentityOptions options = new IdentityOptions();
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                       {
                            new Claim("UserID", user.Id),
                            new Claim(options.ClaimsIdentity.RoleClaimType, user.Role.FirstOrDefault())
                       }),
                Expires = DateTime.Now.AddMinutes(1),
                SigningCredentials = new SigningCredentials(JwtProvider.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)

            };
            return tokenDescriptor;
        }
        public static SecurityTokenDescriptor GenerateSecurityDescriptorForRefreshToken(UserModel user)
        {
            IdentityOptions options = new IdentityOptions();
            var tokenDescriptor = new SecurityTokenDescriptor
            {

                Subject = new ClaimsIdentity(new Claim[]
                       {
                            new Claim("UserID", user.Id),
                            new Claim(options.ClaimsIdentity.RoleClaimType, user.Role.FirstOrDefault())
                       }),
                Expires = DateTime.Now.AddDays(30),
                SigningCredentials = new SigningCredentials(JwtProvider.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)

            };
            return tokenDescriptor;
        }
        public static string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                return Convert.ToBase64String(randomNumber);
            }
        }
    }
}
