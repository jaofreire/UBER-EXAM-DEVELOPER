using Microservices.AwsSESConfig;
using System.Text.RegularExpressions;

namespace Microservices
{
    public static class RouteExtensions
    {
        public static RouteGroupBuilder MapGroup(this RouteGroupBuilder group)
        {

            group.MapPost("/send", async (SESWrapper sesService, EmailModel newEmail) =>
            {
                try
                {
                    var request = sesService.EmailRequest(newEmail.From, newEmail.To, newEmail.Subject, newEmail.Body);
                    await sesService.SendEmail(request);

                    return Results.Ok("EMAIL SENT SUCCESFULLY!!");
                }
                catch (Exception ex)
                {
                    return Results.BadRequest(ex);
                }

            });

            return group;
        }

        public static bool ValidateEmail(string email)
        {
            var expression = new Regex(@"\w+@[a-zA-Z_]+?\.[a-zZ-Z]{2,3}");
            if (expression.IsMatch(email)) return true;

            return false;
        }

    }
}
