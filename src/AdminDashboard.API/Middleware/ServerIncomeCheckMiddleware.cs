namespace AdminDashboard.API.Middleware;

public class ServerIncomeCheckMiddleware
{
    private readonly RequestDelegate _next;

    public ServerIncomeCheckMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"Request: {context.Request.Method} {context.Request.Path} {context.Request.Body}");

        await _next(context);

        Console.WriteLine($"Response: {context.Response.StatusCode}");
    }
}
