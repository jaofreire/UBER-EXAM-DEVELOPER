using DepartureTimeServiceApi.Integration;
using DepartureTimeServiceApi.Integration.Refit;
using Moq;

namespace UnitTest
{
    public class SPTransIntegrationTests
    {
        private Mock<ITransitLandsIntegrationRefit> _refit;

        public SPTransIntegrationTests()
        {
            _refit = new Mock<ITransitLandsIntegrationRefit>();
        }

        [Fact]
        public void Authenticate_IsValid_ReturnTrue()
        {
            string token = Env.Keys.spTransToken;
            var integration = new TransiLandsIntegration(_refit.Object);
            
            var response = integration.AuthenticateApi(token);

            Assert.True(response.Result);

            
        }
    }
}