using DriveSystemWebApplication.Models;


namespace DriveSystemWebApplication.Repository.FileRepository
{
    public class FileRepository:IFileRepository
    {
        private readonly DriveDbContext dbContext;

        public FileRepository(DriveDbContext dbContext) => this.dbContext = dbContext;
        public void Delete(int id)
        {
            Models.File document = GetById(id);
            if (document != null)
            {
                document.IsDeleted = true;
                dbContext.SaveChanges();
            }

        }

        public List<Models.File>? GetAll()
        {
            return dbContext.Files.Where(c => c.IsDeleted != true).ToList();
        }

        public List<Models.File>? GetAllByUserId(int userId)
        {
            return dbContext.Files.Where(c => c.IsDeleted != true && c.UserId == userId).ToList();
        }

        public Models.File? GetById(int id)
        {
            return dbContext.Files.FirstOrDefault(c => c.DocumentId == id);
        }

        public bool Insert(Models.File entity)
        {
            try
            {
                dbContext.Files.Add(entity);
                dbContext.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void Update(int id, Models.File entity)
        {
            throw new NotImplementedException();
        }
    }
}
