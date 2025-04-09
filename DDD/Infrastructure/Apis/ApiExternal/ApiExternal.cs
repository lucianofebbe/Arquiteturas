using Domain.Entities;
using System.Text.Json;

namespace Infrastructure.Apis.ApiExternal
{
    public class ApiExternal<T> where T : BaseDomain, IApiExternal<T>
    {
        private readonly string _baseAddress;
        private readonly string _uriRequest;
        public ApiExternal(string baseAddress, string uriRequest)
        {
            _baseAddress = baseAddress;
            _uriRequest = uriRequest;
        }

        public virtual async Task<List<T>> GetAllTAsync()
        {
            try
            {
                var result = new List<T>();
                result.AddRange(JsonSerializer.Deserialize<List<T>>(GetAllStringAsync().Result));
                return result;

            }
            catch (Exception ex) { throw; }
        }

        public virtual async Task<T> GetTAsync()
        {
            return JsonSerializer.Deserialize<T>(GetStringAsync().Result);
        }

        public virtual async Task<string> GetAllStringAsync()
        {

            try
            {
                var result = new List<T>();
                var response = HttpClient().Result;
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
                var response = HttpClient().Result;
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                return json;

            }
            catch (Exception ex) { throw; }
        }

        private async Task<HttpResponseMessage> HttpClient()
        {
            try
            {
                HttpClient httpClient = new HttpClient() { BaseAddress = new Uri(_baseAddress) };
                var result = await httpClient.GetAsync(_uriRequest);
                return result;
            }
            catch (Exception ex) { throw; }
        }
    }
}
