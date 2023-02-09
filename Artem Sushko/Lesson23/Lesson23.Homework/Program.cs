using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Lesson23.Homework
{
    internal class Program
    {
        class HttpBody
        {
            [JsonProperty("location")]
            public string Location { get; set; }

            [JsonProperty("days")]
            public int Days { get; set; }
        }

        static async Task Main(string[] args)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("https://api.m3o.com"),
                Timeout = TimeSpan.FromSeconds(5)
            };
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "NGYzNmEyNzctOGI1Mi00MGFkLTllMTItYzVkZWE3Yzk3NzE5");

            Console.Write("Enter City: ");
            var city = Console.ReadLine();
            Console.WriteLine("Weather for: 1 - TODAY");
            Console.SetCursorPosition(13, 2);
            Console.WriteLine("2 - TOMOROW");
            var day = Convert.ToInt32(Console.ReadLine());

            var body = new HttpBody
            {
                Location = city,
                Days = day
            };
            Console.Clear();

            var response = await client.PostAsync(
                "v1/weather/Forecast",
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            string[] result = response.Content.ReadAsStringAsync().Result.Split(',');
            foreach (var item in result)
                Console.WriteLine(item);
        }
    }
}
