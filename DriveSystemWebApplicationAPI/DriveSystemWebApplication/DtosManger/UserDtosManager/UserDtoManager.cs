
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

        public UserDto? GetUserDtoByUserCredentials(UserCredentialsDto userCredentialsDto)
        {
            
                var user = userRepository
                    .GetByCredentials(userCredentialsDto.Username,
                                      userCredentialsDto.Password);

                return user == null ?
                       null
                       : new UserDto(
                        user.FirstName,
                        user.LastName,
                        user.Email,
                        user.Password,
                        user.ConfirmPassword);
            

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
