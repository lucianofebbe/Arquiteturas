using Domain.Entities;
using System.Text.Json;

namespace Infrastructure.Apis.ApiExternal
{
    public class ApiExternal<T> : IApiExternal<T> where T : BaseDomain
    {
        private readonly HttpClient _httpClient;
        public ApiExternal(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public virtual async Task<List<T>> GetAllTAsync()
        {
            try
            {
                var result = new List<T>();
                result.AddRange(JsonSerializer.Deserialize<List<T>>(await GetAllStringAsync()));
                return result;

            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<T> GetTAsync()
        {
            return JsonSerializer.Deserialize<T>(await GetStringAsync());
        }

        public virtual async Task<string> GetAllStringAsync()
        {

            try
            {
                var result = new List<T>();
                var response = await _httpClient.GetAsync(string.Empty);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return json;

            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<string> GetStringAsync()
        {
            try
            {
                var result = new List<T>();
                var response = await _httpClient.GetAsync(string.Empty);
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return json;
            }
            catch (Exception ex) { throw; }
        }
    }
}
