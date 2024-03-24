namespace DepartureTimeServiceApi.RouteManipulation
{
    public static class Routes
    {
        public static void Map(WebApplication app)
        {
            app.MapGroup("/apiIntegration").MapGroup();
        }
    }
}
