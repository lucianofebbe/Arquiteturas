using Domain.Entities;
using DTOs.Dtos.Pokemon;
using DTOs.Dtos.Pokemon.Responses;
using Infrastructure.Apis.ApiExternal;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Factory.ApiExternalFactory
{
    public class ApiExternalFactory<T> : IApiExternalFactory<T> where T : class
    {
        public async Task<IApiExternal<T>> CreateAsync(string url)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                return new ApiExternal<T>(client);
            }
            catch (Exception ex) { throw; }
        }

        public async Task<IApiExternal<T>> CreatePokemonsAsync(int offset = 10, int limit = 20, string name = "")
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(GetBaseUrlForPokemons(typeof(T), offset, limit, name));
                return new ApiExternal<T>(client);
            }
            catch (Exception ex) { throw; }
        }

        private string GetBaseUrlForPokemons(Type type, int offset, int limit, string name)
        {
            try
            {
                if (type == typeof(PokemonResponseDto))
                    return $"https://pokeapi.co/api/v2/pokemon/{name}";
                else if (type == typeof(ListPokemonsResponseDto))
                    return $"https://pokeapi.co/api/v2/pokemon?offset={offset}limit={limit}";
                else
                    throw new NotSupportedException($"No API URL configured for type {type.Name}");
            }
            catch (Exception ex) { throw; }
        }
    }
}
