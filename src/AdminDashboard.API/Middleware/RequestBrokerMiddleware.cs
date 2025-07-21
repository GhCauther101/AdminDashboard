using System.Text;

namespace AdminDashboard.API.Middleware;

public class RequestBrokerMiddleware
{
    private readonly RequestDelegate _next;

    public RequestBrokerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        context.Request.EnableBuffering();
        string body = "";
        using (var reader = new StreamReader(
            context.Request.Body,
            encoding: Encoding.UTF8,
            detectEncodingFromByteOrderMarks: false,
            bufferSize: 1024,
            leaveOpen: true))
        {
            body = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
        }

        Console.WriteLine($"Request path: {context.Request.Path}");
        Console.WriteLine($"Request host: {context.Request.Host}");
        Console.WriteLine($"Request method: {context.Request.Method}");
        Console.WriteLine($"Content length: {body.Length}");
        Console.WriteLine($"Content json: {body}");
        Console.WriteLine($"Header : {context.Request.Headers.AccessControlAllowOrigin}");
        Console.WriteLine($"Connection id: {context.Connection.Id}");
        Console.WriteLine($"Connection local address: {context.Connection.LocalIpAddress}");
        Console.WriteLine($"Connection local port: {context.Connection.LocalPort}");
        Console.WriteLine($"Connection remote address: {context.Connection.RemoteIpAddress}");
        Console.WriteLine($"Connection remote port: {context.Connection.RemotePort}");

        Console.WriteLine($"Response status: {context.Response.StatusCode}");
        await _next.Invoke(context);
    }
}