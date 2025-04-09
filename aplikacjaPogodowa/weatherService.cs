using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace aplikacjaPogodowa
{

    class weatherService
    {
        private const string ApiKey = "583a7d2b7d2d27c88e577136b368dcd2";
        private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather";

        private readonly HttpClient _client;

        public weatherService()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData?> GetWeatherAsync(string city)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");

                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                WeatherData? weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

                return weatherData;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Błąd podczas pobierania danych: {ex.Message}");
                return null;
            }
        }

    }
}


public class WeatherData
{
    [JsonProperty("main")]
    public MainData? Main { get; set; }

    [JsonProperty("weather")]
    public WeatherInfo[]? Weather { get; set; }

    [JsonProperty("wind")]
    public WindInfo? Wind { get; set; }
}

public class MainData
{
    [JsonProperty("temp")]
    public float Temperature { get; set; } 

    [JsonProperty("humidity")]
    public float Humidity { get; set; }

    [JsonProperty("pressure")]
    public float Pressure { get; set; }
}

public class WeatherInfo
{

    [JsonProperty("icon")]
    public string? Icon { get; set; }
}

public class WindInfo
{

    [JsonProperty("speed")]
    public float Speed { get; set; }
}
