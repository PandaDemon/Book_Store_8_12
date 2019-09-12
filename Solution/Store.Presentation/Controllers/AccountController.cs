using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.BusinessLogic.JwtProvider;
using Store.BusinessLogic.Models.User;
using Store.BusinessLogic.Services;
using Store.BusinessLogic.Services.Interfaces;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Store.Presentation.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("ConfirmEmail")]
        public async Task<UserModel> ConfirmEmail(string userId, string code)
        {
            if (userId != null && code != null)
            {
                var user = await _userService.FindByIdAsync(userId);
                await _userService.ConfirmEmail(user, code);
                var result = _userService.ConfirmEmail(user, code);
                if (result.Result.Succeeded)
                {
                    return user;
                }
                else
                {
                    foreach (var error in result.Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return null;
        }

        [HttpPost("Register")]
        public async Task<Object> Register([FromBody]UserRegisterModel model)
        {
            IdentityResult res = new IdentityResult();
            if (ModelState.IsValid)
            {
                var result = await _userService.Register(model);
                res = result;
                if (result.Succeeded)
                {
                    string code1 = await _userService.GenerateEmailConfirmationTokenAsync(model);
                    var userView = await _userService.FindByEmailAsync(model.Email);
                    var callbackUrl = Url.RouteUrl("http://localhost:56189/Account/ConfirmEmail?", new { userId = userView.Id, code = code1 });
                    //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userView.Id, code = code1 },
                    //        protocol: Request.Scheme);

                    EmailService.SendMail(model.Email, "Confirm email", "To complete the registration, follow the link :: <a href = \" "
                      + callbackUrl + "\"> complete registration </a> ");

                    return Ok(result);
                }
            }
            return res;
        }

        [HttpGet("Login")]
        public string Login(string returnUrl = null)
        {
            return "login";
        }

        [HttpPost("Login")]
        public async Task<HttpStatusCode> Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userService.FindByEmailAsync(model.Email);
                var result = await _userService.SignInAsync(model);

                if (await _userService.IsEmailConfirmedAsync(user) && result.Succeeded)
                {
                    ClaimsIdentity identity = await _userService.GetIdentityAsync(model.Email, model.Password);
                    if (identity == null)
                    {
                        return HttpStatusCode.RedirectMethod;
                    }
                    var encodedJwt = JwtProvider.GenerateToken(identity.Claims);
                    var response = new
                    {
                        access_token = encodedJwt,
                        username = identity.Name
                    };
                    //JwtSecurityToken<string> refreshToken = new IdentityUserToken<string>();

                    //refreshToken.Name = "refreshToken";
                    //refreshToken.UserId = user.Id;
                    //refreshToken.Value = JwtProvider.GenerateRefreshToken();
                    //refreshToken.LoginProvider = "http://localhost:56189/";
                    //await _userService.CreateToken(refreshToken);
                }
            }
            return HttpStatusCode.OK;
        }

        [HttpPost]
        public async Task<HttpStatusCode> LogOff()
        {
            await _userService.SignOutAsync();
            return HttpStatusCode.Redirect;
        }

        [HttpPost]
        public async Task<HttpStatusCode> RefreshAsync(string token, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            UserModel user = await _userService.FindByEmailAsync(username);
            var newJwtToken = JwtProvider.GenerateToken(principal.Claims);
            IdentityUserToken<string> userTokenRefresh = new IdentityUserToken<string>();

            userTokenRefresh.Name = "refreshToken";
            userTokenRefresh.UserId = user.Id;
            userTokenRefresh.Value = newJwtToken;
            return HttpStatusCode.OK;
        }

        private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false, 
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("the server key used to sign the JWT token is here, use more than 16 chars")),
                ValidateLifetime = false 
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");
            return principal;
        }

        [HttpGet]
        public string ForgotPassword()
        {
            return "Forgot Password";
        }

        [HttpGet("ResetPassword")]
        public HttpStatusCode ResetPassword(string code = null)
        {
            return code == null ? HttpStatusCode.Locked : HttpStatusCode.Redirect;
        }
    }
}
