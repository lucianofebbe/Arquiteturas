using Domain.Entities;
using Infrastructure.Data.UnitOfWork;

namespace Infrastructure.Data.Repositories.PokemonsRepositorie
{
    public class PokemonsRepositorie : UnitOfWork<Pokemons>, IPokemonsRepositorie<Pokemons>
    {
        public PokemonsRepositorie(Context.Context context) : base(context)
        {
        }
    }
}
