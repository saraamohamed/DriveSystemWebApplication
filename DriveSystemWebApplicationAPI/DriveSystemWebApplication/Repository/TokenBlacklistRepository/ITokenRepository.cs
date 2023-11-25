namespace DriveSystemWebApplication.Repository.TokenBlacklistRepository
{
    public interface ITokenReposiatory
    {
        Task<bool> IsCurrentActiveToken();
        Task DeactivateCurrentAsync();
        Task<bool> IsActiveAsync(string token);
        Task DeactivateAsync(string token);
    }
}
