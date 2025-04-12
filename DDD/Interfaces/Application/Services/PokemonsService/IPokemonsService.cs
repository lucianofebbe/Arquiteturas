using Domain.Entities;
using DTOs.Dtos.Pokemon;

namespace Interfaces.Application.Services.PokemonsService
{
    public interface IPokemonsService
    {
        Task<ListPokemonsResponseDto> GetPokemonsAsync(int offset, int limit);

        Task<PokemonResponseDto> GetPokemonAsync(string name = "");
    }
}
