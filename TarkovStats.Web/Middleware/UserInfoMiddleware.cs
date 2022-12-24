using System.Security.Claims;
using TarkovStats.Services;

namespace TarkovStats.Middleware
{
    public static class UserInfoMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserInfo(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserInfoMiddleware>();
        }
    }

    public class UserInfoMiddleware
    {
        private readonly RequestDelegate _next;

        public UserInfoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userInfoHolder = (UserInfoHolder) context.RequestServices.GetRequiredService<UserInfoHolder>();
            if (context.User.Identity?.IsAuthenticated ?? false)
            {
                userInfoHolder.UserInfo = new UserInfo
                {
                    UserId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? "",
                    UserName = context.User.FindFirstValue(ClaimTypes.Name) ?? ""
                };
            }
            await _next(context);
        }
    }
}