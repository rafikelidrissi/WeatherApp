using ApplicationLayer.Dtos;
using Newtonsoft.Json;

namespace ApplicationLayer.Data
{
    public class WeatherService
    {
        private readonly HttpClient _client;

        public WeatherService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherDataAsync()
        {
            var apiUrl = "https://data.buienradar.nl/2.0/feed/json";
            var response = await _client.GetAsync(apiUrl);
            response.EnsureSuccessStatusCode();
            var data = await response.Content.ReadAsStringAsync();
            WeatherData weatherData = JsonConvert.DeserializeObject<WeatherData>(data)!;
            return weatherData;
        }
    }
}