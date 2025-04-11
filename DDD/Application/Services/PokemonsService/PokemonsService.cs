using Domain.Entities;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;

namespace Application.Services.PokemonsService
{
    public class PokemonsService : IPokemonsService
    {
        private IApiExternalFactory<Pokemon> facPokemonApi;
        private IApiExternalFactory<Pokemons> facPokemonsApi;

        public PokemonsService(
            IApiExternalFactory<Pokemon> facPokemonApi,
            IApiExternalFactory<Pokemons> facPokemonsApi)
        {
            this.facPokemonApi = facPokemonApi;
            this.facPokemonsApi = facPokemonsApi;
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

        public async Task<List<Pokemons>> GetPokemonsAsync(int offset, int limit)
        {
            try
            {
                var apiCreate = await this.facPokemonsApi.CreatePokemonsAsync(offset: offset, limit: limit);
                return await apiCreate.GetListAsync();
            }
            catch (Exception ex) { throw; }
        }
    }
}
