using Domain.Bases;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Factory.RepositoryFactory
{
    public interface IRepositoryFactory<T> where T : BaseDomain
    {
        Task<IUnitOfWork<T>> CreateAsync();
    }
}
