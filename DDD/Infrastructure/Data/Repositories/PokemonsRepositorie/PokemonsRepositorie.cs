using Domain.Entities;
using Infrastructure.Data.UnitOfWork;

namespace Infrastructure.Data.Repositories.PokemonsRepositorie
{
    public class PokemonsRepositorie<T> : UnitOfWork<T>, IPokemonsRepositorie<T> where T : BaseDomain
    {
        public PokemonsRepositorie(Context.Context context) : base(context)
        {
        }
    }
}
