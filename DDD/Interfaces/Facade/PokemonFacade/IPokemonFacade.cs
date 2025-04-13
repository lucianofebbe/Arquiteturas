using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;

namespace Interfaces.Facade.PokemonFacade
{
    public interface IPokemonFacade
    {
        Task<ListPokemonsResponseDto> UpdateDataBasePokemonAsync();
        Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request);
        Task<ListPokemonsResponseDto> GetAllPokemonsAsync(ListPokemonsRequestDto request);

    }
}
