using Domain.Entities;
using DTOs.Dtos;

namespace Interfaces.Application.Services.PokemonsService
{
    public interface IPokemonsService
    {
        Task<List<PokemonListDto>> GetPokemonsAsync(int offset, int limit);

        Task<Pokemon> GetPokemonAsync(string name = "");
    }
}
