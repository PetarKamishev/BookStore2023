using BookStore.BL.Interfaces;
using BookStore.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers { 

[ApiController]
public class IdentityController : ControllerBase
{
    private readonly IIdentityService _identityService;

    public IdentityController(IIdentityService identityService)
    {
        _identityService = identityService;
    }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegistrationRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(request.UserName)|| string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }

            var authResult = await _identityService.RegisterAsync(request.UserName, request.Password, request.Email);

            if (!authResult.IsSuccess)
            {
                return Problem($"Error registering user");
            }
            return Ok(authResult);
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] UserRegistrationRequest request)
        {
            var loginResponse = await _identityService.LoginAsync(request.UserName, request.Password);
            if (request == null)
            {
                return BadRequest();
            }

            if (string.IsNullOrEmpty(request.UserName) || string.IsNullOrEmpty(request.Password))
            {
                return BadRequest();
            }
            if (!loginResponse.IsSuccess)
            {
                return Problem($"Error registering user");
            }
            return Ok(loginResponse);
        }
        [HttpPost("LogOff")]
        public async Task LogOff()
        {
            await _identityService.LogOff();
            
        }
}
}
