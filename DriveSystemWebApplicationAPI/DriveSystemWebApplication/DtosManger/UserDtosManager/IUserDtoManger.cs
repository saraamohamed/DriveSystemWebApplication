using DriveSystemWebApplication.DtosManager;
using DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos;

namespace DriveSystemWebApplication.DtosManger.UserDtosManager
{
    public interface IUserDtoManger: IDtosManager<UserDto>
    {
        UserDto? GetUserDtoByUserCredentials(UserCredentialsDto userCredentialsDto);

    }
}
