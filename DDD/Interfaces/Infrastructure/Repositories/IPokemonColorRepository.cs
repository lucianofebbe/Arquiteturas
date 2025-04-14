using Domain.Bases;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Interfaces.Infrastructure.Repositories
{
    public interface IPokemonColorRepository<T> : IUnitOfWork<T> where T : BaseDomain
    {
    }
}
