namespace WebAPI
{
    public class SecurityHeadersMiddleware
    {
        private readonly RequestDelegate next;

        public SecurityHeadersMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public Task Invoke(HttpContext context)
        {
            context.Response.Headers.Add(
                "super-secure", new Microsoft.Extensions.Primitives.StringValues("enable"));

            return next(context);
        }
    }
}
