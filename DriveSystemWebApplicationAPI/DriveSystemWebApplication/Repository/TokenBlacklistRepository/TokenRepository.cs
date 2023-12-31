﻿using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Primitives;



namespace DriveSystemWebApplication.Repository.TokenBlacklistRepository
{
    public class TokenRepository : ITokenReposiatory
    {
      
            private readonly IDistributedCache _cache;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public TokenRepository(IDistributedCache cache,
                    IHttpContextAccessor httpContextAccessor
                )
            {
                _cache = cache;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<bool> IsCurrentActiveToken()
                => await IsActiveAsync(GetCurrentAsync());

            public async Task DeactivateCurrentAsync()
                => await DeactivateAsync(GetCurrentAsync());

            public async Task<bool> IsActiveAsync(string token)
                => await _cache.GetStringAsync(GetKey(token)) == null;

            public async Task DeactivateAsync(string token)
                => await _cache.SetStringAsync(GetKey(token),
                    " ", new DistributedCacheEntryOptions
                    {
                        AbsoluteExpirationRelativeToNow =
                            TimeSpan.FromMinutes(5)
                    });

            private string GetCurrentAsync()
            {
                var authorizationHeader = _httpContextAccessor
                    .HttpContext.Request.Headers["authorization"];

                return authorizationHeader == StringValues.Empty
                    ? string.Empty
                    : authorizationHeader.Single().Split(" ").Last();
            }

            private static string GetKey(string token)
                => $"tokens:{token}:deactivated";
        
    }
}
