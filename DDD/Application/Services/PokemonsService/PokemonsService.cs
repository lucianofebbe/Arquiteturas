using Domain.Entities;
using Interfaces.Application.Services.PokemonsService;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Application.Services.PokemonsService
{
    public class PokemonsService : IPokemonsService
    {
        private IApiExternalFactory<Pokemon> facPokemonApi;
        private IApiExternalFactory<Pokemons> facPokemonsApi;
        private IUnitOfWork<Pokemon> facPokemonRepo;
        private IUnitOfWork<Pokemons> facPokemonsRepo;

        public PokemonsService(
            IApiExternalFactory<Pokemon> facPokemonApi,
            IApiExternalFactory<Pokemons> facPokemonsApi,
            IUnitOfWork<Pokemon> facPokemonRepo,
            IUnitOfWork<Pokemons> facPokemonsRepo)
        {
            this.facPokemonApi = facPokemonApi;
            this.facPokemonsApi = facPokemonsApi;
            this.facPokemonRepo = facPokemonRepo;
            this.facPokemonsRepo = facPokemonsRepo;
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            try
            {
                var apiCreate = await this.facPokemonApi.CreateAsync(name: name);
                return await apiCreate.GetTAsync();
            }
            catch (Exception ex) { throw; }
        }

        public async Task<List<Pokemons>> GetPokemonsAsync(int limit)
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
