using Domain.Entities;
using Factory.ApiExternalFactory;

namespace Application.Services.PokemonsService
{
    public class PokemonsService : IPokemonsService
    {
        private IApiExternalFactory<Pokemon> apiExternalFactoryPokemon;
        private IApiExternalFactory<Pokemons> apiExternalFactoryPokemons;

        public PokemonsService(
            IApiExternalFactory<Pokemon> apiExternalFactoryPokemon,
            IApiExternalFactory<Pokemons> apiExternalFactoryPokemons)
        {
            this.apiExternalFactoryPokemon = apiExternalFactoryPokemon;
            this.apiExternalFactoryPokemons = apiExternalFactoryPokemons;
        }

        public async Task<Pokemon> GetPokemonAsync(string name)
        {
            try
            {
                var apiCreate = await this.apiExternalFactoryPokemon.CreateAsync(name: name);
                return await apiCreate.GetTAsync();
            }
            catch (Exception ex) { throw; }
        }

        public async Task<List<Pokemons>> GetPokemonsAsync(int limit)
        {
            try
            {
                var apiCreate = await this.apiExternalFactoryPokemons.CreateAsync(limit: limit);
                return await apiCreate.GetAllTAsync();
            }
            catch (Exception ex) { throw; }
        }
    }
}
