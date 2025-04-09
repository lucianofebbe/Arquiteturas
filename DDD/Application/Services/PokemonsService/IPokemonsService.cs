using Domain.Entities;

namespace Application.Services.PokemonsService
{
    public interface IPokemonsService
    {
        Task<Pokemons> GetPokemonsAsync();

        Task<Pokemon> GetPokemonAsync();
    }
}
