using DepartureTimeServiceApi.Integration;
using Env;

namespace DepartureTimeServiceApi.RouteManipulation
{
    public static class RoutesExtension
    {

        public static RouteGroupBuilder MapGroup(this RouteGroupBuilder group)
        {
            group.MapGet("/get/linhas", async (ISPTransIntegration integration, string termosBusca) =>
            {
                try
                {
                    var token = Keys.spTransToken;

                    if (integration.AuthenticateApi(token).Result)
                        return Results.Ok(await integration.GetLinhaApi(termosBusca));

                    return Results.BadRequest("Not Authorized");

                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex);
                }

            });

            group.MapPost("/authenticate", async (ISPTransIntegration integration) =>
            {
                try
                {
                    var token = Keys.spTransToken;
                    var result = await integration.AuthenticateApi(token);

                    return Results.Ok(result);
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex);
                }

            });


            return group;
        }

    }
}
