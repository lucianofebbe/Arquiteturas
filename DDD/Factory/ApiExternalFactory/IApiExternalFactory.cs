using Domain.Entities;
using Infrastructure.Apis.ApiExternal;

namespace Factory.ApiExternalFactory
{
    public interface IApiExternalFactory<T> where T : BaseDomain
    {
        Task<IApiExternal<T>> CreateAsync(int limit = 20, string name = "");
    }
}
