using Domain.Entities;
using Infrastructure.Data.UnitOfWork;

namespace Infrastructure.Data.Repositories.PokemonColorRepositorie
{
    public class PokemonColorRepositorie : UnitOfWork<PokemonColor>, IPokemonColorRepositorie<PokemonColor>
    {
        public PokemonColorRepositorie(Context.Context context) : base(context)
        {
        }
    }
}
