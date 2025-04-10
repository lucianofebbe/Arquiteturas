using Domain.Entities;

namespace Interfaces.Application.Services.PokemonsService
{
    public interface IPokemonsService
    {
        Task<List<Pokemons>> GetPokemonsAsync(int limit);

        Task<Pokemon> GetPokemonAsync(string name);
    }
}
