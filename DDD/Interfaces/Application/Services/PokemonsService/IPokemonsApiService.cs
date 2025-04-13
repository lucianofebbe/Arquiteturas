using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;

namespace Interfaces.Application.Services.PokemonsService
{
    public interface IPokemonsApiService
    {
        Task<ListPokemonsResponseDto> GetPokemonsAsync(ListPokemonsRequestDto request);

        Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request);
    }
}
