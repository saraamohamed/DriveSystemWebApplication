
    namespace DriveSystemWebApplication.DtosManager
    {
        public interface IDtosManager<T>
        {
            List<T> GetAllDtos();
            T? GetDtoById(int id);
            bool InsertEntityUsingDto(T entity);
            bool UpdateEntityUsingDto(T entity);
            bool DeleteEntity(int id);
        }
    }

