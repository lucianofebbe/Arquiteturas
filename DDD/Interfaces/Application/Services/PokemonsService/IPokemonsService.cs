using Domain.Entities;

namespace Interfaces.Application.Services.PokemonsService
{
    public interface IPokemonsService
    {
        Task<List<Pokemons>> GetPokemonsAsync(int limit = 10);

        Task<Pokemon> GetPokemonAsync(string name = "");
    }
}
