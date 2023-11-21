namespace DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos
{
    public sealed record UserFilesDto(
     string FirstName,
     string LastName,
     string Password,
     string Email,
     string ConfirmPassword,
     List<Models.File> Files
  );
}
