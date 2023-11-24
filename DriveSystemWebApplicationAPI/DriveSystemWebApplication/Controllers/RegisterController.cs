using DriveSystemWebApplication.DtosManger.UserDtosManager;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using Microsoft.AspNetCore.Mvc;

namespace DriveSystemWebApplication.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private IUserDtoManger userDtosManager;

        public RegisterController(IUserDtoManger userDtosManager)
            => this.userDtosManager = userDtosManager;

        [HttpPost]
        public IActionResult AddAccount(UserDto NewAccount)
        {
            return userDtosManager.InsertEntityUsingDto(NewAccount) ? Ok("Registration successful") : BadRequest("Invalid request");

            //    if (HttpContext.Request.Method == "POST")
            //    {
            //        if (ModelState.IsValid)
            //        {
            //            User user = new User
            //            {
            //                FirstName = NewAccount.FirstName,
            //                LastName = NewAccount.LastName,
            //                Email = NewAccount.Email,
            //                Password = NewAccount.Password,
            //                ConfirmPassword = NewAccount.ConfirmPassword
            //            };

            //            _dbContext.Users.Add(user);
            //            _dbContext.SaveChanges();

            //            return Ok("Registration successful");
            //        }
            //        else
            //        {
            //            return BadRequest(ModelState);
            //        }
            //    }

            //    return BadRequest("Invalid request");
            //}
        }
    }
}
   
