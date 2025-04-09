using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WheatherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private WeatherService _ws; 
        public MainWindow()
        {
            InitializeComponent();
            _ws = new WeatherService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            string city = "Gliwice";

            WeatherData? weatherData = await _ws.GetWeatherAsync(city);

            if (weatherData != null)
            {
                string weatherInfo = $"Temperatura: {weatherData?.Main?.Temperature}°C\n";
                weatherInfo += $"Wilgotność: {weatherData?.Main?.Humidity}%\n";
                weatherInfo += $"Opis: {weatherData?.Weather?[0].Description}";

                wyswietlacz.Text = weatherInfo;
            }
            else
            {
                wyswietlacz.Text = "Błąd pobierania danych pogodowych.";
            }
        }
    }
}