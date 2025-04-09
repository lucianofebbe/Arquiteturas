using Domain.Entities;
using Infrastructure.Apis.ApiExternal;

namespace Factory.ApiExternalFactory
{
    public class ApiExternalFactory<T> : IApiExternalFactory<T> where T : BaseDomain
    {
        public IApiExternal<T> CreateAsync()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(GetBaseUrlFor(typeof(T)));
            return new ApiExternal<T>(client);
        }

        private string GetBaseUrlFor(Type type)
        {
            try
            {
                if (type == typeof(Pokemon))
                    return "https://pokeapi.co/api/v2/pokemon/";
                else if (type == typeof(Pokemons))
                    return "https://pokeapi.co/api/v2/pokemon?limit=151";
                else
                    throw new NotSupportedException($"No API URL configured for type {type.Name}");
            }
            catch (Exception ex) { throw; }
        }
    }
}
