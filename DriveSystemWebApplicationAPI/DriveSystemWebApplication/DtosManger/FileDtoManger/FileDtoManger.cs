using DriveSystemWebApplication.DtosManger.FileDtoManger.FileDtos;

using DriveSystemWebApplication.Repository.FileRepository;

namespace DriveSystemWebApplication.DtosManger.FileDtoManger
{
    public class FileDtoManger : IFileDtoManger
    {
        private readonly IFileRepository fileRepository
            ;
        public FileDtoManger(IFileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }
        public bool DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<FileDto> GetAllDtos()
        {
            throw new NotImplementedException();
        }

        public List<FileDto> GetAllFilesDtosByUserId(int userId)
        {
            var docments = fileRepository.GetAllByUserId(userId);

            var docmentDtos = new List<FileDto>();

            docments.ForEach(docment =>
            {
                docmentDtos.Add(new FileDto(
                   docment.Name,docment.FileType,docment.DataFiles,docment.CreatedOn,docment.UserId));
            });

            return docmentDtos ;

        }

        public FileDto? GetDtoById(int id)
        {
            throw new NotImplementedException();
        }

        public bool InsertEntityUsingDto(FileDto entity)
        {
            throw new NotImplementedException();
        }

        public bool UpdateEntityUsingDto(FileDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
