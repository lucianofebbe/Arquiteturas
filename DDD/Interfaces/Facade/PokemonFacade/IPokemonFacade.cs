using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;

namespace Interfaces.Facade.PokemonFacade
{
    public interface IPokemonFacade
    {
        Task<ListPokemonsResponseDto> UpdateDataBasePokemonAsync(CancellationToken cancellationToken);
        Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken);
        Task<ListPokemonsResponseDto> GetAllPokemonsAsync(ListPokemonsRequestDto request, CancellationToken cancellationToken);

    }
}
