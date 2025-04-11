using Domain.Bases;
using Domain.Entities;
using DTOs.Bases;
using DTOs.Dtos;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Factory.MappersFactory;

namespace Application.Services.PokemonsService
{
    public class PokemonsService : IPokemonsService
    {
        private IApiExternalFactory<Pokemon> facPokemonApi;
        private IApiExternalFactory<PokemonListDto> facPokemonsApi;
        private IMapperFactory<BaseDomain, BaseRequest, PokemonListDto> facMapperPokemon;

        public PokemonsService(
            IApiExternalFactory<Pokemon> facPokemonApi,
            IApiExternalFactory<PokemonListDto> facPokemonsApi,
            IMapperFactory<BaseDomain, BaseRequest, PokemonListDto> facMapperPokemon)
        {
            this.facPokemonApi = facPokemonApi;
            this.facPokemonsApi = facPokemonsApi;
            this.facMapperPokemon = facMapperPokemon;
        }

        public async Task<Pokemon> GetPokemonAsync(string name = "")
        {
            try
            {
                var result = new Pokemon();
                var apiCreate = await this.facPokemonApi.CreatePokemonsAsync(name: name);
                var json = await apiCreate.GetJsonAsync();
                return result;
            }
            catch (Exception ex) { throw; }
        }

        public async Task<List<PokemonListDto>> GetPokemonsAsync(int offset, int limit)
        {
            try
            {
                var result = new List<PokemonListDto>();
                var apiCreate = await this.facPokemonsApi.CreatePokemonsAsync(offset: offset, limit: limit);
                var json = await apiCreate.GetJsonAsync();
                return result;
            }
            catch (Exception ex) { throw; }
        }
    }
}
