namespace DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos
{
    public sealed record UserDto(
       
       string FirstName,
       string LastName,
       string Password,
       string Email,
       string ConfirmPassword
    );

}
