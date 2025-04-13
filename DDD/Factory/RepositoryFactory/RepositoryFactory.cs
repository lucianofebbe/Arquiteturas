using Domain.Bases;
using Factory.RepositoryFactory;
using Infrastructure.Data.Context;
using Infrastructure.Data.UnitOfWork;
using Interfaces.Infrastructure.Apis.ApiExternal;
using Microsoft.EntityFrameworkCore;

namespace Factory.RepositorieFactory
{
    public class RepositoryFactory<T> : IRepositoryFactory<T> where T : BaseDomain
    {
        public async Task<IUnitOfWork<T>> CreateAsync()
        {
            try
            {
                var optionsBuilder = new DbContextOptionsBuilder<Context>();
                var context = new Context(optionsBuilder.Options);

                var unitOfWork = new UnitOfWork<T>(context);
                return unitOfWork;
            }
            catch (Exception ex) { throw; }
        }
    }
}
