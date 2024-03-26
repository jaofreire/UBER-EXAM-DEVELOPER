namespace DepartureTimeServiceApi.Integration
{
    public interface ISPTransIntegration
    {
        Task<bool> AuthenticateApi(string token);
        Task<List<LinhasModel>> GetLinhaApi(string termosBusca);
    }
}
