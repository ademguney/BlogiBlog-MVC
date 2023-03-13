namespace Blogi.Application.Services.VisitorInformationService
{
    public interface IVisitorInformationService
    {
        Task<bool> GetAsync(string ipAddress, string path);
        Task AddAsync(string ipAddress, string path);
    }
}