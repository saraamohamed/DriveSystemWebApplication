using MVC_Task_Codid.Repository;

namespace DriveSystemWebApplication.Repository.FileRepository
{
    public interface IFileRepository:IRepository<Models.File>
    {
       List<Models.File> GetAllByUserId(int userId);
    }
}
