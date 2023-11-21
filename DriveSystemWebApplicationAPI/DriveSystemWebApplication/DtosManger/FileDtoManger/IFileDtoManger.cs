
using DriveSystemWebApplication.DtosManager;

namespace DriveSystemWebApplication.DtosManger.FileDtoManger.FileDtos
{
    public interface IFileDtoManger: IDtosManager<FileDto>
    {
        List<FileDto> GetAllFilesDtosByUserId(int userId);

    }
}
