using Domain.Entities;
using Factory.RepositorieFactory;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Application.Services.PokemonsService
{
    public class PokemonsService : IPokemonsService
    {
        private IApiExternalFactory<Pokemon> facPokemonApi;
        private IApiExternalFactory<Pokemons> facPokemonsApi;
        private IRepositorieFactory<Pokemon> facPokemonRepo;
        private IRepositorieFactory<Pokemons> facPokemonsRepo;

        public PokemonsService(
            IApiExternalFactory<Pokemon> facPokemonApi,
            IApiExternalFactory<Pokemons> facPokemonsApi,
            IRepositorieFactory<Pokemon> facPokemonRepo,
            IRepositorieFactory<Pokemons> facPokemonsRepo)
        {
            this.facPokemonApi = facPokemonApi;
            this.facPokemonsApi = facPokemonsApi;
            this.facPokemonRepo = facPokemonRepo;
            this.facPokemonsRepo = facPokemonsRepo;
        }

        public async Task<Pokemon> GetPokemonAsync(string name = "")
        {
            try
            {
                var apiCreate = await this.facPokemonApi.CreateAsync(name: name);
                return await apiCreate.GetTAsync();
            }
            catch (Exception ex) { throw; }
        }

        public async Task<List<Pokemons>> GetPokemonsAsync(int limit = 20)
        {
            try
            {
                var apiCreate = await this.facPokemonsApi.CreateAsync(limit: limit);
                return await apiCreate.GetAllTAsync();
            }
            catch (Exception ex) { throw; }
        }
    }
}
