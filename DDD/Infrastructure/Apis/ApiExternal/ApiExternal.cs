using Interfaces.Infrastructure.Apis.ApiExternal;
using System.Text.Json;

namespace Infrastructure.Apis.ApiExternal
{
    public class ApiExternal<T> : IApiExternal<T> where T : class
    {
        private readonly HttpClient _httpClient;
        public ApiExternal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<List<T>> GetListAsync()
        {
            try
            {
                var result = new List<T>();
                var json = await GetJsonAsync();
                result.AddRange(JsonSerializer.Deserialize<List<T>>(json));
                return result;

            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<T> GetAsync()
        {
            try
            {
                var json = await GetJsonAsync();
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<string> GetJsonAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync(string.Empty);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return json;

            }
            catch (Exception ex) { throw; }
        }
    }
}
