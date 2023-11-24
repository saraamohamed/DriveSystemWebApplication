namespace DriveSystemWebApplication.Repository.TokenBlacklistRepository
{
    public class TokenBlacklistRepository : ITokenBlacklistService
    {
        private static List<string> revokedTokens = new List<string>();

        public void AddToBlacklist(string token)
        {
            revokedTokens.Add(token);
        }

        public bool IsTokenRevoked(string token)
        {
            return revokedTokens.Contains(token);
        }
    }
}
