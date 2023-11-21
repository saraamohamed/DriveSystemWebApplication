using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using DriveSystemWebApplication.Repository.UserRepository;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace DriveSystemWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("login")]
        public IActionResult LoginUser(UserCredentialsDto credentials)
        {
            var user = _userRepository.GetByCredentials(credentials.Email, credentials.Password);

            if (user != null)
            {
                // Your authentication logic
                ClaimsIdentity claims = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),

                    // Add more claims as needed
                });
                ClaimsPrincipal principal = new ClaimsPrincipal(claims);


                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Ok("Login successful");
            }

            return BadRequest("Invalid credentials");
        }

        [Authorize]
        [HttpPost("signout")]
        public IActionResult SignOut()
        {
            
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok("Sign out successful");
        }

    }
}
