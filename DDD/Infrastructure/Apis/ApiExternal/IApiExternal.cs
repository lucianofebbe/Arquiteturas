using Domain.Entities;

namespace Infrastructure.Apis.ApiExternal
{
    public interface IApiExternal<T> where T : BaseDomain
    {
        Task<List<T>> GetAllTAsync();
        Task<T> GetTAsync();
        Task<string> GetAllStringAsync();
        Task<string> GetStringAsync();
    }
}
