using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using DriveSystemWebApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DriveSystemWebApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly DriveDbContext _dbContext;
        public RegisterController(DriveDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult AddAccount(UserDto NewAccount)
        {
            ModelState.Clear();

            if (HttpContext.Request.Method == "POST")
            {
                if (ModelState.IsValid)
                {
                    User user = new User
                    {
                        FirstName = NewAccount.FirstName,
                        LastName = NewAccount.LastName,
                        Email = NewAccount.Email,
                        Password = NewAccount.Password,
                        ConfirmPassword = NewAccount.ConfirmPassword
                    };

                    _dbContext.Users.Add(user);
                    _dbContext.SaveChanges();

                    return Ok("Registration successful");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }

            return BadRequest("Invalid request");
        }
    }
}
   
