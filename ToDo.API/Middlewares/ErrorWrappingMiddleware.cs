using ToDo.Services.Exceptions;

namespace ToDo.API.Middlewares
{
    public class ErrorWrappingMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorWrappingMiddleware(RequestDelegate next)
        {
            _next = next;
            Message = "";
        }

        private string Message { get; set; }

        public async Task Invoke(HttpContext context)
        {
            Message = "";
            try
            {
                await _next.Invoke(context);
            }
            catch (EntityNotFoundException ex)
            {
                Message = ex.Message;
                context.Response.StatusCode = ex.HttpCode;
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = 500;
                Message = ex.Message;
            }
        }
    }
}