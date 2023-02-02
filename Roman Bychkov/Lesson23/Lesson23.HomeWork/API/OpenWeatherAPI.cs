using Newtonsoft.Json;

namespace Lesson23.HomeWork.API
{
    internal class OpenWeatherAPI
    {
        private string _token;

        public OpenWeatherAPI(string token = "abbab0581d660382e8adb459cb7351f1")
        {
            _token = token;
        }
        public async Task<string> CreateRequestAsync(double latitude, double longitude)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.openweathermap.org");
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            
            var response = await httpClient.GetAsync(
               $"data/2.5/weather?lat=" + latitude.ToString().Replace(',', '.') + "&lon=" + longitude.ToString().Replace(',', '.') + "&appid=" + _token);
            var responseContent = await response.Content.ReadAsStringAsync();

            string result = JsonConvert.DeserializeObject<ResponseBody>(responseContent).ToString();
            Console.WriteLine(result);
            return result;
        }
        class ResponseBody
        {

            [JsonProperty("main")]
            public ResponseBodyInner Info { get; set; }

            public override string ToString()
            {
                return $"OpenWeather || Temp C: {Info.TempK - 273}, Feels like: {Info.FeelsLike - 273}";
            }
        }
        class ResponseBodyInner
        {
            [JsonProperty("temp")]
            public double TempK { get; set; }

            [JsonProperty("feels_like")]
            public double FeelsLike { get; set; }
        }


    }
}
