using Domain.Entities;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Factory.RepositorieFactory
{
    public interface IRepositorieFactory<T> where T : BaseDomain
    {
        Task<IUnitOfWork<T>> CreateAsync();
    }
}
