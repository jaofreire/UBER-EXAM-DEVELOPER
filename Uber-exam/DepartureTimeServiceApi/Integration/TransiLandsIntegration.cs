using DepartureTimeServiceApi.Integration.Refit;
using Newtonsoft.Json;

namespace DepartureTimeServiceApi.Integration
{
    public class TransiLandsIntegration : ITransitLandsIntegration
    {
        
        private readonly ITransitLandsIntegrationRefit _refitSPTrans;


        public TransiLandsIntegration(ITransitLandsIntegrationRefit refitSPTrans)
        {
            _refitSPTrans = refitSPTrans;
        }

        
    }
}
