using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Weather: ");
            string apiKey = "322c0a7851b8ad7f4f78c1648672ae49";

            Console.WriteLine("Less than 80");
            Console.Write("Enter Latitude: ");
            double latitude = double.Parse(Console.ReadLine());
            Console.Write("Enter Longitude: ");
            double longitude = double.Parse(Console.ReadLine());

            using (var client = new HttpClient())
            {
                string url = $"https://api.openweathermap.org/data/2.5/weather?lat={latitude}&lon={longitude}&appid={apiKey}&units=metric";
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);

                string location = data.name;
                string description = data.weather[0].description;
                double temperature = data.main.temp;

                Console.WriteLine($"Current weather in {location}: {description}, {temperature}°C");
            }

            Console.Write("\nCats fact: ");
            using(var client = new HttpClient())
            {
                string url = "https://meowfacts.herokuapp.com/?lang=ukr";
                var response = await client.GetAsync(url);

                string json = await response.Content.ReadAsStringAsync();
                dynamic data = JsonConvert.DeserializeObject(json);
                dynamic fact = data;

                Console.WriteLine(fact.data[0]);
            }
        }
    }
}
