using Amazon.Runtime.Internal.Util;
using BookStore.BL.Interfaces;
using BookStore.Models.Models.Configurations.Identity;
using BookStore.Models.Models.Users;
using BookStore.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookStore.BL.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<Models.Models.Users.IdentityUser> _userManager;
        private readonly SignInManager<Models.Models.Users.IdentityUser> _signInManager;
        private readonly JwtSettings _jwtSettings;
        private readonly ILogger<IdentityService> _logger;

        public IdentityService(UserManager<Models.Models.Users.IdentityUser> userManager, SignInManager<Models.Models.Users.IdentityUser> signInManager, JwtSettings jwtSettings, ILogger<IdentityService> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _jwtSettings = jwtSettings;
        }
        public async Task<AuthenticationResult> LoginAsync(string userName, string password)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user == null)
            {
                _logger.LogWarning($"User {user} does not exist!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Error = new string[] { $"Username/Password combination is incorrect!" }
                };
            }
            var validPassword = await _userManager.CheckPasswordAsync(user, password);
            if (!validPassword) 
            {
                _logger.LogWarning($"User {user} wrong password!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Error = new string[] { $"Username/Password combination is incorrect!" }
                };
            }

            return await GenerateAuthenticationResult(user);
        }

        public async Task LogOff()
        {
           await _signInManager.SignOutAsync();
        }

        public async Task<AuthenticationResult> RegisterAsync(string userName, string password, string email)
        {
            var existingUser = await _userManager.FindByNameAsync(userName);
            if (existingUser != null)
            {
                _logger.LogWarning($"User already exists!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Error = new string[] { $"User already exists!" }
                };
            }

            var user = new Models.Models.Users.IdentityUser()
            {
                UserName = userName,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
            {
                _logger.LogWarning($"Error registering user!");
                return new AuthenticationResult()
                {
                    IsSuccess = false,
                    Error = new string[] { $"Error registering user!" }
                };
            }

            return await GenerateAuthenticationResult(user);
        }
        private async Task<AuthenticationResult> GenerateAuthenticationResult(Models.Models.Users.IdentityUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                    }
                    ),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials= new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            await _signInManager.SignInAsync(user, false);

            return new AuthenticationResult()
            {
                IsSuccess = true,
                Error = new string[] { },
                Token = tokenHandler.WriteToken(token)
            };
        }
    }
}
