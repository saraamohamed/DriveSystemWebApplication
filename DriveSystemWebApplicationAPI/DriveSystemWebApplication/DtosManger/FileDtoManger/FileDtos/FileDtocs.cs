namespace DriveSystemWebApplication.DtosManger.FileDtoManger.FileDtos
{
    public sealed record FileDto(
      string Name,
      string FileType,
      byte[] DataFiles,
      DateTime? CreatedOn,
      int UserId
   );
}
