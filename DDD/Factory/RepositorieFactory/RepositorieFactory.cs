using Domain.Entities;
using Infrastructure.Data.Context;
using Infrastructure.Data.UnitOfWork;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Factory.RepositorieFactory
{
    public class RepositorieFactory<T> : IRepositorieFactory<T> where T : BaseDomain
    {
        public async Task<IUnitOfWork<T>> CreateAsync()
        {
            try
            {
                var context = new Context();
                var unitOfWork = new UnitOfWork<T>(context);
                return unitOfWork;
            }
            catch (Exception ex) { throw; }
        }
    }
}
