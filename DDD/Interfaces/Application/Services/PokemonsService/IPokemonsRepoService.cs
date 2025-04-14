using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;

namespace Interfaces.Application.Services.PokemonsService
{
    public interface IPokemonsRepoService
    {
        Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken);
        Task<PokemonResponseDto> InsertPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken);
        Task<PokemonResponseDto> UpdatePokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken);
        Task<PokemonResponseDto> DeletePokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken);
        Task<ListPokemonsResponseDto> GetPokemonsAsync(ListPokemonsRequestDto request, CancellationToken cancellationToken);
        Task<ListPokemonsResponseDto> InsertPokemonsAsync(PokemonRequestDto request,CancellationToken cancellationToken);
        Task<ListPokemonsResponseDto> UpdatePokemonsAsync(PokemonRequestDto request,CancellationToken cancellationToken);
        Task<ListPokemonsResponseDto> DeletePokemonsAsync(PokemonRequestDto request, CancellationToken cancellationToken);
    }
}
