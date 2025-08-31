using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Linq;

public class AdminAuthMiddleware
{
    private readonly RequestDelegate _next;

    public AdminAuthMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var path = context.Request.Path.Value?.ToLower();

        var protectedPaths = new[] {"admin/dashboard" ,"/rooms", "/bookings", "/clients" };
        bool isProtected = protectedPaths.Any(path.StartsWith);

        if (isProtected)
        {
            var isLoggedIn = context.Session.GetString("AdminLoggedIn");

            if (isLoggedIn != "true")
            {
                context.Response.Redirect("/admin/login");
                return;
            }
        }

        await _next(context);
    }
}
