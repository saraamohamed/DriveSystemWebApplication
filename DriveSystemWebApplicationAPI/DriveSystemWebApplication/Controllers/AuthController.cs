using Microsoft.AspNetCore.Mvc;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using System.Security.Claims;
using DriveSystemWebApplication.DtosManger.UserDtosManager;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using DriveSystemWebApplication.Validators;
using DriveSystemWebApplication.Repository.TokenBlacklistRepository;


namespace DriveSystemWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserDtoManger userDtosManager;
        private readonly ITokenReposiatory tokenReposiatory;

        public AuthController(IUserDtoManger userDtosManager,ITokenReposiatory tokenReposiatory)
        {
            this.userDtosManager = userDtosManager;
            this.tokenReposiatory = tokenReposiatory;
        }
        [HttpPost("register")]
        public IActionResult AddAccount(UserDto NewAccount)
        {
            return userDtosManager.InsertEntityUsingDto(NewAccount) ?
                Ok("Registration successful") : BadRequest("Invalid request");


        }

        [HttpPost("login")]
        public IActionResult AuthenticateLogger(UserCredentialsDto userCredentials)
        {
            var user = userDtosManager
                .GetUserDtoByUserCredentials(userCredentials);

            if (user != null)
            {
                GlobalSessionValidator.IsInSession = true;

                List<Claim> userIdentityClaims = new()
                {
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.SerialNumber, user.UserId.ToString())
                   
                };


                // Define a secret key for the current token.
                string secretKey = "DriveWebAppAPIDevelopedByCodid";
                var encodedSecretKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                // Write the token.
                var signingCredentials = new SigningCredentials(encodedSecretKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: userIdentityClaims,
                    signingCredentials: signingCredentials,
                    expires: DateTime.Now.AddDays(1));

                var stringifiedToken = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new { generatedJwtToken = stringifiedToken });
            }

            return Unauthorized();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> CancelAccessToken()
        {
            await tokenReposiatory.DeactivateCurrentAsync();

            return NoContent();
        }
    }

 }

