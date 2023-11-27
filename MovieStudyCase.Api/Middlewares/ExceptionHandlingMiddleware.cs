using MovieStudyCase.Services.Dto.Common;
using MovieStudyCase.Services.Exceptions;
using Newtonsoft.Json;

namespace MovieStudyCase.Api.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context, IWebHostEnvironment env)
    {
        try
        {
            await _next(context);
        }
        catch (StateException ex)
        {
            await HandleExceptionAsync(context, ex, env);
        }           
    }

    private static Task HandleExceptionAsync(HttpContext context, StateException exception, IWebHostEnvironment env)
    {
        var status = new ResponseState( 400, exception.Message);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = status.StatusCode;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(status));
    }

}