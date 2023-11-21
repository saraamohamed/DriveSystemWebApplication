using DriveSystemWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace DriveSystemWebApplication.Repository.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly DriveDbContext dbContext;

        public UserRepository(DriveDbContext dbContext) => this.dbContext = dbContext;
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<User>? GetAll()
        {
            return dbContext
                          .Users
                          .ToList();
        }

        public User? GetById(int userId)
        {
            return dbContext
                            .Users
                            .FirstOrDefault(user =>
                                user.UserId == userId
                                );
        }
        public User? GetByCredentials(string email, string password)
        {
            return dbContext
                .Users
                .FirstOrDefault(user =>
                    user.Email == email &&
                    user.Password == password
                    );
        }

        public bool Insert(User user)
        {
            try
            {
                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(int id, User entity)
        {
            throw new NotImplementedException();
        }
    }
}
