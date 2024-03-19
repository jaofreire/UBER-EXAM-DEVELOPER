namespace Microservices
{
    public static class Routes
    {
        public static void Map(WebApplication app)
        {
            app.MapGroup("/email").MapGroup().WithTags("EmailService");
        }
    }
}
