using DriveSystemWebApplication.Repository.TokenBlacklistRepository;
using System.Net;

namespace DriveSystemWebApplication.Middelware
{
    public class TokenManagerMiddleware : IMiddleware
    {
        private readonly ITokenReposiatory tokenReposiatory;

        public TokenManagerMiddleware(ITokenReposiatory tokenReposiatory)
        {
            this.tokenReposiatory = tokenReposiatory;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            if (await tokenReposiatory.IsCurrentActiveToken())
            {
                await next(context);

                return;
            }
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}
