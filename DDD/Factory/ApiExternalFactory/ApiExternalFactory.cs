using Infrastructure.Apis.ApiExternal;
using Interfaces.Factory.ApiExternalFactory;
using Interfaces.Infrastructure.Apis.ApiExternal;

namespace Factory.ApiExternalFactory
{
    public class ApiExternalFactory<T> : IApiExternalFactory<T> where T : class
    {
        private readonly Dictionary<Type, IUrlBuilder> urlStrategies;
        public ApiExternalFactory(IEnumerable<IUrlBuilder> builders)
        {
            this.urlStrategies = builders.ToDictionary(b => b.TargetType, b => b);
        }
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
                if (urlStrategies.TryGetValue(type, out var builder))
                    return builder.BuildUrl(offset, limit, name);

                throw new NotSupportedException($"No URL strategy configured for type {type.Name}");
            }
            catch (Exception ex) { throw; }
        }
    }
}
