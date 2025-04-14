using Domain.Bases;
using Infrastructure.Data.UnitOfWork;
using Interfaces.Infrastructure.Repositories;

namespace Infrastructure.Data.Repositories
{
    public class PokemonRepository<T> : UnitOfWork<T>, IPokemonRepository<T> where T : BaseDomain
    {
        public PokemonRepository(Context.Context context) : base(context)
        {
        }
        
    }
}
