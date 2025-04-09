using Domain.Entities;
using Infrastructure.Data.UnitOfWork;

namespace Infrastructure.Data.Repositories.PokemonRepositorie
{
    public class PokemonRepositorie : UnitOfWork<Pokemon>, IPokemonRepositorie<Pokemon>
    {
        public PokemonRepositorie(Context.Context context) : base(context)
        {
        }
    }
}
