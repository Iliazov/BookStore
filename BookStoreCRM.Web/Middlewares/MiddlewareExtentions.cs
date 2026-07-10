namespace BookStoreCRM.Web.Middlewares
{
    public static class MiddlewareExtentions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(
        this IApplicationBuilder app)
        {
            return app.UseMiddleware<GlobalExceptionHandlingMiddleware>();
        }
    }
}
