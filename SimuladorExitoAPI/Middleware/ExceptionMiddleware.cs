
using SimuladorExitoAPI.Exceptions;
using System.Text.Json;

namespace SimuladorExitoAPI.Middleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (NotFoundException ex)
            {
                context.Response.StatusCode = (int)ex.statusCode;
                await context.Response.WriteAsync(JsonSerializer.Serialize(ex.data));
                
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(JsonSerializer.Serialize(ex.Message));
            }
        }
    }
}
