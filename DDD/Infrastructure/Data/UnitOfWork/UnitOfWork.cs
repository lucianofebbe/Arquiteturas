using Domain.Bases;
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

        public virtual async Task<bool> SoftDelete(int id, CancellationToken cancellationToken)
        {
            try
            {
                var resultFind = await Get(a => a.Id == id, cancellationToken);
                if (resultFind != null)
                {
                    resultFind.Updated = DateTime.Now;
                    resultFind.Deleted = true;
                    var inserted = await Insert(resultFind, cancellationToken);
                    return inserted.Id > 0;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<T> Get(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool noTracking = false, bool? deleteds = null)
        {
            try
            {
                var query = context.Set<T>().AsQueryable();
                query = query.Where(predicate);

                if (deleteds != null)
                    query = query.Where(del => del.Deleted == deleteds);

                if (noTracking)
                    query = query.AsNoTracking();

                return await query.FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public virtual async Task<List<T>> GetAll(CancellationToken cancellationToken, bool noTracking = false, int skip = 0, int take = 0, bool? deleteds = null)
        {
            try
            {
                var query = context.Set<T>().AsQueryable();

                if (deleteds != null)
                    query = query.Where(del => del.Deleted == deleteds);

                if (noTracking)
                    query = query.AsNoTracking();

                if (skip > 0)
                    query = query.Skip(skip);

                if (take > 0)
                    query = query.Take(take);

                return await query.ToListAsync(cancellationToken);
            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<List<T>> GetAll(Expression<Func<T, bool>> predicate, CancellationToken cancellationToken, bool noTracking = false, int skip = 0, int take = 0, bool? deleteds = null)
        {
            try
            {
                var query = context.Set<T>().AsQueryable();
                query = query.Where(predicate);

                if (deleteds != null)
                    query = query.Where(del => del.Deleted == deleteds);

                if (noTracking)
                    query = query.AsNoTracking();

                if (skip > 0)
                    query = query.Skip(skip);

                if (take > 0)
                    query = query.Take(take);

                return await query.ToListAsync(cancellationToken);
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
                entidade.Guid = Guid.NewGuid();
                entidade.Created = DateTime.Now;
                entidade.Updated = DateTime.Now;
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
                entidade.Updated = DateTime.Now;
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
