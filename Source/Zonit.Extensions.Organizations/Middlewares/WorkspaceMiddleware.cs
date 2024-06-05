using Microsoft.AspNetCore.Http;

namespace Zonit.Extensions.Organizations.Middlewares;

internal class WorkspaceMiddleware(RequestDelegate _next)
{
    public async Task InvokeAsync(
        HttpContext httpContext,
        IWorkspaceManager Workspace
    )
    {
        await Workspace.InicjalizeAsync();
        await _next(httpContext);
    }
}