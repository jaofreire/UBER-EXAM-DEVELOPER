using Microsoft.AspNetCore.Mvc;
using Refit;

namespace DepartureTimeServiceApi.Integration.Refit
{
    public interface ISPTransIntegrationRefit
    {
        [Post("/Login/Autenticar?token={token}")]
        Task<bool> Authenticate(string token);

        [Get("/Linha/Buscar?termosBusca={termosBusca}}")]
        Task<LinhasModel> GetLinhas(string termosBusca);


    }
}
