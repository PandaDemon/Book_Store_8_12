using Microsoft.IdentityModel.Tokens;
using PrintStore.BusinessLogic.ViewModels;

namespace PrintStore.BusinessLogic.Helpers.Interface
{
    public interface IJwtHelper
    {
        SecurityTokenDescriptor GenerateSecurityDescriptorForRefreshToken(ApplicationUserViewModel user);
        SecurityTokenDescriptor GenerateSecurityTokenDescriptor(ApplicationUserViewModel user);
    }
}
