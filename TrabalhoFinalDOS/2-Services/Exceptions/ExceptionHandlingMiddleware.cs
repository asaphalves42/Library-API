using System.Net;

namespace TrabalhoFinalDOS._2_Services.Exceptions
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            _logger.LogError(exception, "Ocorreu um erro.");
            ExceptionResponse response = exception switch
            {
                ExcepcaoHTTP _ => new ExceptionResponse(((ExcepcaoHTTP)exception).HTTPCode, ((ExcepcaoHTTP)exception).Mensagem),
                _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Ocorreu um erro interno")
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)response.StatusCode;
            var responseObject = new
            {
                mensagem = response.Mensagem
            };
            await context.Response.WriteAsJsonAsync(responseObject);
        }
        public record ExceptionResponse(HttpStatusCode StatusCode, string Mensagem);

    }

    public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }


    }
}
