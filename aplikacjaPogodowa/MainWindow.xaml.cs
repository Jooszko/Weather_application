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

namespace aplikacjaPogodowa
{
    public partial class MainWindow : Window
    {
        private weatherService _ws;
        private bool czyZListy = true;
        public MainWindow()
        {
            InitializeComponent();
            _ws = new weatherService();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            
            string city = "";

            if (czyZListy)
            {
                if (pickCity.SelectedItem is ComboBoxItem selectedItem)
                {
                    city = selectedItem.Content.ToString();
                }

            }
            else
            {
                city = cityTextBox.Text;
            }

            if (!city.Equals(""))
            {

                

                WeatherData? weatherData = await _ws.GetWeatherAsync(city);
                if (weatherData != null)
                {
                    string weatherInfo = $"Temperatura: {weatherData?.Main?.Temperature}°C\n";
                    weatherInfo += $"Wilgotność: {weatherData?.Main?.Humidity}%\n";
                    weatherInfo += $"Ciśnienie: {weatherData?.Main?.Pressure}hPa\n";
                    weatherInfo += $"Prędkość wiatru: {weatherData?.Wind?.Speed}km/h\n";

                    string fotoName = $"https://openweathermap.org/img/wn/{weatherData?.Weather?[0].Icon}@2x.png";
                    fotoPogoda.Source = new BitmapImage(new Uri(fotoName));

                    wyswietlacz.Text = weatherInfo;
                }
                else
                {
                    wyswietlacz.Text = "Niepoprawna nazwa miasta!";
                }
            }
            else
            {
                wyswietlacz.Text = "Wybierz miasto!";
            }
        }

        private void cityTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(cityTextBox.Text))
            {
                pickCity.SelectedIndex = -1;
                czyZListy=false;
            }
        }

        private void pickCity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (pickCity.SelectedItem != null)
            {
                cityTextBox.Text = string.Empty;
                czyZListy = true;
            }
        }
    }
}