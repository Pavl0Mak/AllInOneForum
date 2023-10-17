using AllInOneForum.Middlewares;

namespace AllInOneForum.Extensions
{
    public static class MiddwaresRegistrationExtension
    {
        public static WebApplication? RegisterMiddlewares(this WebApplication? app)
        {
            app?.UseMiddleware<LogHeadersMiddleware>();

            return app;
        }
    }
}
