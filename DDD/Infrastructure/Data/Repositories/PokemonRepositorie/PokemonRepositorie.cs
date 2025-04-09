using Domain.Entities;
using Infrastructure.Data.UnitOfWork;

namespace Infrastructure.Data.Repositories.PokemonRepositorie
{
    public class PokemonRepositorie<T> : UnitOfWork<T>, IPokemonRepositorie<T> where T : BaseDomain
    {
        public PokemonRepositorie(Context.Context context) : base(context)
        {
        }
    }
}
