using Domain.Bases;
using DTOs.Bases;
using DTOs.Dtos.Pokemon;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Factory.MappersFactory;

namespace Application.Services.PokemonsService
{
    public class PokemonsService : IPokemonsService
    {
        private IApiExternalFactory<PokemonResponseDto> facPokemonApi;
        private IMapperFactory<BaseDomain, BaseRequest, PokemonResponseDto> facPokemonMapper;

        private IApiExternalFactory<ListPokemonsResponseDto> facListPokemonsApi;
        private IMapperFactory<BaseDomain, BaseRequest, ListPokemonsResponseDto> facListPokemonsMapper;

        public PokemonsService(
            IApiExternalFactory<PokemonResponseDto> facPokemonApi,
            IMapperFactory<BaseDomain, BaseRequest, PokemonResponseDto> facPokemonMapper,
            IApiExternalFactory<ListPokemonsResponseDto> facListPokemonsApi,
            IMapperFactory<BaseDomain, BaseRequest, ListPokemonsResponseDto> facListPokemonsMapper)
        {
            this.facPokemonApi = facPokemonApi;
            this.facPokemonMapper = facPokemonMapper;
            this.facListPokemonsApi = facListPokemonsApi;
            this.facListPokemonsMapper = facListPokemonsMapper;
        }

        public async Task<PokemonResponseDto> GetPokemonAsync(string name = "")
        {
            var result = new PokemonResponseDto();
            try
            {
                var facPokemons = await this.facPokemonApi.CreatePokemonsAsync(name: name);
                var getJsonAsync = await facPokemons.GetJsonAsync();

                if (!string.IsNullOrEmpty(getJsonAsync))
                {
                    var facMapper = await facPokemonMapper.CreateAsync();
                    var mapper = await facMapper.JsonToResponse(getJsonAsync);
                    result = mapper;
                }
                else
                    result.Message = "Pokemon not found";

                return result;
            }
            catch (Exception ex)
            {
                result.Message = ex.Message;
                return result;
            }
        }

        public async Task<ListPokemonsResponseDto> GetPokemonsAsync(int offset, int limit)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var facPokemons = await facListPokemonsApi.CreatePokemonsAsync(offset: offset, limit: limit);
                var getJsonAsync = await facPokemons.GetJsonAsync();

                if (!string.IsNullOrEmpty(getJsonAsync))
                {
                    var facMapper = await facListPokemonsMapper.CreateAsync();
                    var mapper = await facMapper.JsonToResponse(getJsonAsync);
                    result = mapper;
                }
                else 
                    result.Message = "Pokemon not found";
                
                return result;
            }
            catch (Exception ex) {
                result.Message = ex.Message;
                return result;
            }
        }
    }
}
