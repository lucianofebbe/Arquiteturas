using Domain.Entities;
using System.Linq.Expressions;

namespace Interfaces.Infrastructure.Apis.ApiExternal
{
    public interface IUnitOfWork<T>
        where T : BaseDomain
    {
        Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool? deleteds = null);
        Task<List<T>> GetAll(CancellationToken cancellationToken, bool? deleteds = null);
        Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool? deleteds = null);
        Task<T> Insert(T entidade, CancellationToken cancellationToken);
        Task<T> Update(T entidade, CancellationToken cancellationToken);
        Task<bool> Delete(int id, CancellationToken cancellationToken);
    }
}
