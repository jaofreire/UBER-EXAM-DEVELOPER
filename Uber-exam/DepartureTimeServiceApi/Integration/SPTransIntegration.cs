using DepartureTimeServiceApi.Integration.Refit;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace DepartureTimeServiceApi.Integration
{
    public class SPTransIntegration : ISPTransIntegration
    {
        
        private readonly ISPTransIntegrationRefit _refitSPTrans;

        public SPTransIntegration(ISPTransIntegrationRefit refitSPTrans)
        {
            _refitSPTrans = refitSPTrans;
        }

        public async Task<bool> AuthenticateApi(string token)
        {
            return await _refitSPTrans.Authenticate(token);
        }

        public async Task<LinhasModel> GetLinhaApi(string termosBusca)
        {
            return await _refitSPTrans.GetLinhas(termosBusca);
        }
    }
}
