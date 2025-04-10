using Domain.Entities;
using Interfaces.Infrastructure.Apis.ApiExternal;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Data.UnitOfWork
{
    public class UnitOfWork<T> : IUnitOfWork<T>
        where T : BaseDomain
    {
        public Context.Context context;

        public UnitOfWork(Context.Context context)
        {
            this.context = context;
        }

        public virtual async Task<bool> Delete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var resultFind = await Get(a => a.Id == id, cancellationToken);
                if (resultFind != null)
                {
                    resultFind.Deleted = true;
                    return Insert(resultFind, cancellationToken).Result.Id > 0;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool? deleteds = null)
        {
            try
            {
                if (deleteds == null)
                    return await context.Set<T>()
                        .Where(predicate).FirstOrDefaultAsync();
                else
                {
                    return await context.Set<T>()
                        .Where(del => del.Deleted == deleteds)
                        .Where(predicate).FirstOrDefaultAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<T>> GetAll(CancellationToken cancellationToken, bool? deleteds = null)
        {
            try
            {
                if (deleteds == null)
                    return await context.Set<T>().ToListAsync(cancellationToken);
                else
                {
                    return await context.Set<T>()
                        .Where(del => del.Deleted == deleteds).ToListAsync(cancellationToken);
                }
            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool? deleteds = null)
        {
            try
            {
                if (deleteds == null)
                    return await context.Set<T>()
                        .Where(predicate).ToListAsync();
                else
                {
                    return await context.Set<T>()
                        .Where(del => del.Deleted == deleteds)
                        .Where(predicate).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<T> Insert(T entidade, CancellationToken cancellationToken)
        {
            try
            {
                context.Entry(entidade).State = EntityState.Added;
                await context.SaveChangesAsync(cancellationToken);
                return entidade;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<T> Update(T entidade, CancellationToken cancellationToken)
        {
            try
            {
                context.Entry(entidade).State = EntityState.Modified;
                await context.SaveChangesAsync(cancellationToken);
                return entidade;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
