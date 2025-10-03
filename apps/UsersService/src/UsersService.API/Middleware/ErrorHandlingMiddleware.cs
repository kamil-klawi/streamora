using UsersService.Application.Exceptions;

namespace UsersService.API.Middleware
{
    public class ErrorHandlingMiddleware : IMiddleware
    {
        private readonly ILogger<ErrorHandlingMiddleware> _logger;

        public ErrorHandlingMiddleware(ILogger<ErrorHandlingMiddleware> logger)
        {
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (BadRequestException msg)
            {
                _logger.LogWarning(msg.Message);
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync(msg.Message);
            }
            catch (UnauthorizedException msg)
            {
                _logger.LogWarning(msg.Message);
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync(msg.Message);
            }
            catch (ForbiddenException msg)
            {
                _logger.LogWarning(msg.Message);
                context.Response.StatusCode = StatusCodes.Status403Forbidden;
                await context.Response.WriteAsync(msg.Message);
            }
            catch (NotFoundException msg)
            {
                _logger.LogWarning(msg.Message);
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync(msg.Message);
            }
            catch (Exception msg)
            {
                _logger.LogError(msg.Message);
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync(msg.Message);
            }
        }
    }
}
