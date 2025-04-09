using Domain.Entities;
using Infrastructure.Data.UnitOfWork;

namespace Infrastructure.Data.Repositories.PokemonColorRepositorie
{
    public class PokemonColorRepositorie<T> : UnitOfWork<T>, IPokemonColorRepositorie<T> where T : BaseDomain
    {
        public PokemonColorRepositorie(Context.Context context) : base(context)
        {
        }
    }
}
