using DriveSystemWebApplication.DtosManager;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;
using DriveSystemWebApplication.Models;

namespace DriveSystemWebApplication.DtosManger.UserDtosManager
{
    public interface IUserDtoManger: IDtosManager<UserDto>
    {
        User? GetUserDtoByUserCredentials(UserCredentialsDto userCredentialsDto);

    }
}
