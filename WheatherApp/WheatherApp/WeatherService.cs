using Newtonsoft.Json; // Potrzebne do deserializacji JSON
using System;
using System.Net.Http;
using System.Threading.Tasks;


// Serwis pogodowy pobierający dane z API OpenWeatherMap
public class WeatherService
{
    private const string ApiKey = "";
    private const string BaseUrl = "http://api.openweathermap.org/data/2.5/weather";

    // Obiekt HttpClient do wykonywania żądań HTTP
    private readonly HttpClient _client;

    public WeatherService()
    {
        _client = new HttpClient();
    }

    // Metoda asynchroniczna pobierająca dane pogodowe dla podanego miasta
    // async oznacza, że metoda może działać asynchronicznie.
    // await oznacza, że program nie blokuje wykonywania kodu, tylko czeka na odpowiedź z API.
    // Task<T> jest typem zwracanym przez metody asynchroniczne – reprezentuje obiekt, który będzie miał wartość w przyszłości.
    // Dzięki async/await aplikacja nie blokuje głównego wątku, co jest kluczowe dla responsywności
    public async Task<WeatherData?> GetWeatherAsync(string city)
    {
        try
        {
            // Wysyłamy asynchroniczne żądanie GET do API
            HttpResponseMessage response = await _client.GetAsync($"{BaseUrl}?q={city}&appid={ApiKey}&units=metric");

            // Sprawdzenie, czy odpowiedź jest poprawna (status 200 OK)
            response.EnsureSuccessStatusCode();

            // Pobranie treści odpowiedzi jako string
            string responseBody = await response.Content.ReadAsStringAsync();

            // Deserializacja JSON do obiektu WeatherData
            WeatherData? weatherData = JsonConvert.DeserializeObject<WeatherData>(responseBody);

            return weatherData;
        }
        catch (HttpRequestException ex)
        {
            // Obsługa błędu HTTP
            Console.WriteLine($"Błąd podczas pobierania danych: {ex.Message}");
            return null;
        }
    }
}


// Klasa reprezentująca strukturę danych pogodowych (zgodnie z formatem JSON zwracanym przez API)
public class WeatherData
{
    [JsonProperty("main")]
    public MainData? Main { get; set; }

    [JsonProperty("weather")]
    public WeatherInfo[]? Weather { get; set; }
}

public class MainData
{
    [JsonProperty("temp")]
    public float Temperature { get; set; } // Lepsza nazwa niż "Temp"

    [JsonProperty("humidity")]
    public float Humidity { get; set; }
}

public class WeatherInfo
{
    [JsonProperty("description")]
    public string? Description { get; set; }
}
