using Domain.Entities;
using Infrastructure.Apis.ApiExternal;

namespace Factory.ApiExternalFactory
{
    public interface IApiExternalFactory<T> where T : BaseDomain
    {
        IApiExternal<T> CreateAsync();
    }
}
