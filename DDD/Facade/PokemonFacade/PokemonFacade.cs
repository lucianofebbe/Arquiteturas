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

        public async Task<ListPokemonsResponseDto> UpdateDataBasePokemonAsync(CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var pokemonsApi = new ListPokemonsResponseDto();
                var pokemonsRepo = new List<ListPokemonsResponseDto>();

                #region GetAllPokemonsinApi
                var paramApi = new ListPokemonsRequestDto();
                var servicePokemons = await pokemonsApiService.GetPokemonsAsync(paramApi);
                paramApi.limit = servicePokemons.Count;
                pokemonsApi = await pokemonsApiService.GetPokemonsAsync(paramApi);
                #endregion

                #region GetAllPokemonsRepo
                var paramRepo = new ListPokemonsRequestDto();
                var repoPokemons = await pokemonsRepoService.GetPokemonsAsync(paramRepo, cancellationToken);
                #endregion

                var nomesApi = pokemonsApi.Results.Select(p => p.Name).ToHashSet();
                var nomesRepo = pokemonsRepo
                    .SelectMany(repo => repo.Results)
                    .Select(p => p.Name)
                    .ToHashSet();

                var paraInserir = nomesApi.Except(nomesRepo).ToList();
                var paraDesativar = nomesRepo.Except(nomesApi).ToList();

                paraInserir.ForEach(item =>
                {
                    var pokemonRequestDto = new PokemonRequestDto() { Name = item };
                    pokemonsRepoService.InsertPokemonsAsync(pokemonRequestDto, cancellationToken);
                });

                paraDesativar.ForEach(item =>
                {
                    var pokemonRequestDto = new PokemonRequestDto() { Name = item };
                    pokemonsRepoService.DeletePokemonsAsync(pokemonRequestDto, cancellationToken);
                });

                result.Message = "DataBase Updated!";
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<PokemonResponseDto> GetPokemon(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                var servicePokemon = await pokemonsApiService.GetPokemonAsync(request);
                var repoPokemon = await pokemonsRepoService.GetPokemonAsync(request, cancellationToken);

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
