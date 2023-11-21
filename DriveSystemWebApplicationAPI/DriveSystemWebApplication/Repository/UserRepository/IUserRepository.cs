using DriveSystemWebApplication.Models;
using MVC_Task_Codid.Repository;

namespace DriveSystemWebApplication.Repository.UserRepository
{
    public interface IUserRepository: IRepository<User>
    {
        User? GetByCredentials(string email, string password);

    }
}
