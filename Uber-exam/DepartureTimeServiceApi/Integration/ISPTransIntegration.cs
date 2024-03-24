namespace DepartureTimeServiceApi.Integration
{
    public interface ISPTransIntegration
    {
        Task<bool> AuthenticateApi(string token);
        Task<LinhasModel> GetLinhaApi(string termosBusca);
    }
}
