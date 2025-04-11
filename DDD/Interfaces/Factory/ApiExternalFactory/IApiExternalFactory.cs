using Domain.Bases;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Interfaces.Factory.ApiExternalFactory
{
    public interface IApiExternalFactory<T> where T : BaseDomain
    {
        Task<IApiExternal<T>> CreateAsync(string url);
        Task<IApiExternal<T>> CreatePokemonsAsync(int offset = 10, int limit = 20, string name = "");
    }
}
