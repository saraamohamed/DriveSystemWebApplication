
using DriveSystemWebApplication.Models;
using DriveSystemWebApplication.Repository.UserRepository;

namespace DriveSystemWebApplication.DtosManger.UserDtosManager.UserDtos
{
    public class UserDtoManager : IUserDtoManger
    {
        private readonly IUserRepository userRepository;

        public UserDtoManager(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public bool DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<UserDto> GetAllDtos()
        {
            throw new NotImplementedException();
        }

        public UserDto? GetDtoById(int id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserDtoByUserCredentials(UserCredentialsDto userCredentialsDto)
        {
            
                var userDto = userRepository
                    .GetByCredentials(userCredentialsDto.Email,
                                      userCredentialsDto.Password);
                if (userDto != null)
                {
                    var user = new User();
                    user.UserId = userDto.UserId;
                    user.FirstName= userDto.FirstName;
                    user.LastName= userDto.LastName;
                    user.Email = userDto.Email;
                    user.Password = userDto.Password;
                    user.ConfirmPassword= userDto.ConfirmPassword;
                    return user ;

                }
                else
                {
                    return null;
                }
               
        }

        public bool InsertEntityUsingDto(UserDto entity)
        {
            return userRepository.Insert(new Models.User()
            {
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Email = entity.Email,
                Password = entity.Password,
                ConfirmPassword = entity.ConfirmPassword,
            });
        }

        public bool UpdateEntityUsingDto(UserDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
