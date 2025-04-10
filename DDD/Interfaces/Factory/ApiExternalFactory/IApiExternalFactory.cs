using Domain.Entities;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Interfaces.Factory.ApiExternalFactory
{
    public interface IApiExternalFactory<T> where T : BaseDomain
    {
        Task<IApiExternal<T>> CreateAsync(int limit = 20, string name = "");
    }
}
