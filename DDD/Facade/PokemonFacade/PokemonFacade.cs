using Domain.Entities;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Facade.PokemonFacade;
using System.ComponentModel;

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
                var servicePokemon = await pokemonsApiService.GetPokemonsAsync(paramApi);
                paramApi.limit = servicePokemon.Count;
                pokemonsApi = await pokemonsApiService.GetPokemonsAsync(paramApi);
                #endregion

                #region GetAllPokemonsRepo
                var paramRepo = new ListPokemonsRequestDto();
                var repoPokemon = await pokemonsRepoService.GetPokemonsAsync(paramRepo, cancellationToken);
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
                    pokemonsRepoService.InsertPokemonAsync(new PokemonRequestDto() { name = item }, cancellationToken);
                });

                paraDesativar.ForEach(item =>
                {
                    pokemonsRepoService.DeletePokemonAsync(new PokemonRequestDto() { name = item }, cancellationToken);
                });

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ListPokemonsResponseDto> GetAllPokemonsAsync(ListPokemonsRequestDto request, CancellationToken cancellationToken)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
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
