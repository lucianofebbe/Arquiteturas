using Domain.Bases;
using DTOs.Dtos.Pokemon.Requests;
using DTOs.Dtos.Pokemon.Responses;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Factory.MappersFactory;

namespace Application.Services.PokemonsService
{
    public class PokemonsApiService : IPokemonsApiService
    {
        private IApiExternalFactory<PokemonResponseDto> facPokemonApi;
        private IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto> facPokemonMapper;

        private IApiExternalFactory<ListPokemonsResponseDto> facListPokemonsApi;
        private IMapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto> facListPokemonsMapper;

        public PokemonsApiService(
            IApiExternalFactory<PokemonResponseDto> facPokemonApi,
            IMapperFactory<BaseDomain, PokemonRequestDto, PokemonResponseDto> facPokemonMapper,
            IApiExternalFactory<ListPokemonsResponseDto> facListPokemonsApi,
            IMapperFactory<BaseDomain, PokemonRequestDto, ListPokemonsResponseDto> facListPokemonsMapper)
        {
            this.facPokemonApi = facPokemonApi;
            this.facPokemonMapper = facPokemonMapper;
            this.facListPokemonsApi = facListPokemonsApi;
            this.facListPokemonsMapper = facListPokemonsMapper;
        }

        public async Task<PokemonResponseDto> GetPokemonAsync(PokemonRequestDto request)
        {
            var result = new PokemonResponseDto();
            try
            {
                var facPokemons = await this.facPokemonApi.CreatePokemonsAsync(name: request.name);
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

        public async Task<ListPokemonsResponseDto> GetPokemonsAsync(ListPokemonsRequestDto request)
        {
            var result = new ListPokemonsResponseDto();
            try
            {
                var facPokemons = await facListPokemonsApi.CreatePokemonsAsync(offset: request.offset, limit: request.limit);
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
