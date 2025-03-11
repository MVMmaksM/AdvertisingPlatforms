using System.Web;

namespace AdvertisingPlatformsApi.Middlewares;
/// <summary>
/// миддлеваре для логгирования запросов и ответов
/// </summary>
/// <param name="next"></param>
/// <param name="logger"></param>
public class LoggerMiddleware(RequestDelegate next, ILogger<LoggerMiddleware> logger)
{
    public async Task InvokeAsync(HttpContext context)
    {
        var request = context.Request;
        logger.LogInformation(
            $"[{DateTime.Now}] request: {request.Method}|{request.Host.ToString() + request.Path + HttpUtility.UrlDecode(request.QueryString.ToString())}" +
            $"|{request.Protocol}|{request.Scheme}");

        await next.Invoke(context);

        var responce = context.Response;
        logger.LogInformation(
            $"[{DateTime.Now}] responce: {request.Method}|{request.Host.ToString() + request.Path + HttpUtility.UrlDecode(request.QueryString.ToString())}" +
            $"|{request.Protocol}|{request.Scheme}");
    }
}