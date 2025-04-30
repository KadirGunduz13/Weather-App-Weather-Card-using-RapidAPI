using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Windows.Forms;

namespace Project13_WeatherApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/Kirklareli/EN"),
                Headers =
    {
        { "x-rapidapi-key", "165f4ec062mshdc1e54df851edb1p19a528jsn10b3bb79ae56" },
        { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                
                var json = JObject.Parse(body);
                var fahrenheit = json["main"]["feels_like"].ToString();
                var windSpeed = json["wind"]["speed"].ToString();
                var humidity = json["main"]["humidity"].ToString();
                decimal celsius = (decimal.Parse(fahrenheit) - 32) / (decimal)1.8m;
                lblFahrenheit.Text = fahrenheit;
                lblWind.Text = windSpeed;
                lblHumidity.Text = humidity;
                lblCelsius.Text = celsius.ToString("0.00");

            }
        }
    }
}
