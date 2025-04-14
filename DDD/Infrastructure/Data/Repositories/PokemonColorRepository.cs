using Domain.Bases;
using Infrastructure.Data.UnitOfWork;
using Interfaces.Infrastructure.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class PokemonColorRepository<T> : UnitOfWork<T>, IPokemonColorRepository<T> where T : BaseDomain
    {
        public PokemonColorRepository(Context.Context context) : base(context)
        {
        }
    }
}
