using Domain.Bases;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Facade.PokemonFacade;
using Interfaces.Factory.MappersFactory;
using System.Xml.XPath;

namespace Facade.PokemonFacade
{
    public class PokemonFacade : IPokemonFacade
    {
        private IPokemonsApiService pokemonsApiService;
        private IPokemonsRepoService pokemonsRepoService;
        private IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto> facPokemonMapper;

        public PokemonFacade(
            IPokemonsApiService pokemonsApiService,
            IPokemonsRepoService pokemonsRepoService,
            IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto> facPokemonMapper)
        {
            this.pokemonsApiService = pokemonsApiService;
            this.pokemonsRepoService = pokemonsRepoService;
            this.facPokemonMapper = facPokemonMapper;
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

        public async Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            try
            {
                if (string.IsNullOrEmpty(request.Name) && request.guid == Guid.Empty)
                {
                    result.Message = "Insert value into parameters";
                    return result;
                }

                if (request.guid != Guid.Empty)
                {
                    result = await GetPokemonRepoByGuidAsync(request, cancellationToken);

                    if (result == null)
                    {
                        result = new PokemonResponseDto();
                        result.Message = "Pokemon Not Found";
                        return result;
                    }
                    else
                        return result;
                }

                if (!string.IsNullOrEmpty(request.Name))
                {
                    var repoPokemon = await pokemonsRepoService.GetPokemonAsync(request, cancellationToken);
                    if (repoPokemon == null)
                    {
                        var servicePokemon = await pokemonsApiService.GetPokemonAsync(request);
                        if (servicePokemon == null)
                        {
                            result.Message = "Pokemon not found";
                            return result;
                        }
                        else
                        {
                            var mapper = await facPokemonMapper.CreateAsync();
                            var responsePokemon = await mapper.ResponseToRequest(servicePokemon);
                            result = await pokemonsRepoService.InsertPokemonAsync(responsePokemon, cancellationToken);
                        }
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        private async Task<PokemonResponseDto> GetPokemonRepoByGuidAsync(PokemonRequestDto request, CancellationToken cancellationToken)
        {
            var result = new PokemonResponseDto();
            var repoPokemon = await pokemonsRepoService.GetPokemonAsync(request, cancellationToken);
            result = repoPokemon;
            return result;
        }
    }
}
