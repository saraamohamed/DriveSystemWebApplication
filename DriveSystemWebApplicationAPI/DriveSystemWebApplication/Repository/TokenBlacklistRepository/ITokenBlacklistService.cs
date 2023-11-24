namespace DriveSystemWebApplication.Repository.TokenBlacklistRepository
{
    public interface ITokenBlacklistService
    {
        void AddToBlacklist(string token);
        bool IsTokenRevoked(string token);
    }
}
