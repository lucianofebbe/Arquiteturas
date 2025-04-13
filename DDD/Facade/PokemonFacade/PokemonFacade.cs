using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Facade.PokemonFacade;

namespace Facade.PokemonFacade
{
    public class PokemonFacade : IPokemonFacade
    {
        private IPokemonsApiService pokemonsApiService;
        private IPokemonsRepoService pokemonsRepoService;
        public PokemonFacade(
            IPokemonsApiService pokemonsApiService,
            IPokemonsRepoService pokemonsRepoService)
        {
            this.pokemonsApiService = pokemonsApiService;
            this.pokemonsRepoService = pokemonsRepoService;
        }


        public Task<ListPokemonsResponseDto> UpdateDataBasePokemonAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request)
        {
            throw new NotImplementedException();
        }

        public Task<ListPokemonsResponseDto> GetAllPokemonsAsync(ListPokemonsRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
