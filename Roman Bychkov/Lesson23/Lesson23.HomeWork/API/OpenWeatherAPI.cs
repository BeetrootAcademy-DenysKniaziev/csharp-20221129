using Newtonsoft.Json;

namespace Lesson23.HomeWork.API
{
    internal class OpenWeatherAPI
    {
        private string _token;
        private HttpClient _httpClient;
        public OpenWeatherAPI(string token)
        {
            _token = token;
            _httpClient = new HttpClient();
        }
        public async Task<string> CreateRequestAsync(double latitude, double longitude)
        {

            _httpClient.BaseAddress = new Uri("https://api.openweathermap.org");
            _httpClient.Timeout = TimeSpan.FromSeconds(10);

            var response = await _httpClient.GetAsync(
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
