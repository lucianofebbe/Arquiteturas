using DTOs.Dtos.Pokemon;
using DTOs.Dtos.Pokemon.Responses;

namespace Interfaces.Facade.PokemonFacade
{
    public interface IPokemonFacade
    {
        Task<ListPokemonsResponseDto> AtualizarBaseDadosPokemonAsync();
        Task<PokemonResponseDto> BuscarPokemonAsync(string name);
        Task<ListPokemonsResponseDto> ListarPokemonsAsync(int offset, int limit);

    }
}
