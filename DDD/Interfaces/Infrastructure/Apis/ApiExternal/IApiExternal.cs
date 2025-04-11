using Domain.Entities;

namespace Interfaces.Infrastructure.Apis.ApiExternal
{
    public interface IApiExternal<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<T> GetAsync();
        Task<string> GetJsonAsync();
    }
}
