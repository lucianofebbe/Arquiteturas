using Domain.Entities;
using Infrastructure.Apis.ApiExternal;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Factory.ApiExternalFactory
{
    public class ApiExternalFactory<T> : IApiExternalFactory<T> where T : BaseDomain
    {
        public async Task<IApiExternal<T>> CreateAsync(int limit = 20, string name = "")
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(GetBaseUrlFor(typeof(T), limit, name));
                return new ApiExternal<T>(client);
            }
            catch (Exception ex) { throw; }
        }

        private string GetBaseUrlFor(Type type, int limit = 20, string name = "")
        {
            try
            {
                if (type == typeof(Pokemon))
                    return $"https://pokeapi.co/api/v2/pokemon/{name}";
                else if (type == typeof(Pokemons))
                    return $"https://pokeapi.co/api/v2/pokemon?limit={limit}";
                else
                    throw new NotSupportedException($"No API URL configured for type {type.Name}");
            }
            catch (Exception ex) { throw; }
        }
    }
}
