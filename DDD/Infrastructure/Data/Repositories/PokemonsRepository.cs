using Domain.Bases;
using Infrastructure.Data.UnitOfWork;
using Interfaces.Infrastructure.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class PokemonsRepository<T> : UnitOfWork<T>, IPokemonsRepository<T> where T : BaseDomain
    {
        public PokemonsRepository(Context.Context context) : base(context)
        {
        }
    }
}
