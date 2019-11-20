using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using PrintStore.BusinessLogic.Helpers.Interface;
using PrintStore.BusinessLogic.ViewModels;
using System;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PrintStore.BusinessLogic.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        public const string KEY = "cd099ee4-be37-4bda!123";
        public const string USERID = "UserID";
        public const int ACCESSTIME = 1;
        public const int REFRESHTIMEDAYS = 30;

        public SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
        }

        public SecurityTokenDescriptor GenerateSecurityTokenDescriptor(ApplicationUserViewModel user)
        {
            IdentityOptions options = new IdentityOptions();

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                       {
                            new Claim(USERID, user.Id),
                            new Claim(options.ClaimsIdentity.RoleClaimType, user.RoleName.FirstOrDefault())
                       }),
                Expires = DateTime.Now.AddMinutes(ACCESSTIME),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }

        public SecurityTokenDescriptor GenerateSecurityDescriptorForRefreshToken(ApplicationUserViewModel user)
        {
            IdentityOptions options = new IdentityOptions();

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                       {
                            new Claim(USERID, user.Id),
                            new Claim(options.ClaimsIdentity.RoleClaimType, user.RoleName.FirstOrDefault())
                       }),
                Expires = DateTime.Now.AddDays(REFRESHTIMEDAYS),
                SigningCredentials = new SigningCredentials(GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256Signature)
            };

            return tokenDescriptor;
        }
    }
}
