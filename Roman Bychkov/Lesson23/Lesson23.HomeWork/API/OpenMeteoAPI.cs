using Newtonsoft.Json;
using System.Text;

namespace Lesson23.HomeWork.API
{
    internal class OpenMeteoAPI
    {
        private HttpClient _httpClient;
        public OpenMeteoAPI()
        {
            _httpClient = new HttpClient();
        }
        public async Task<string> CreateRequestAsync(double latitude, double longitude)
        {
            _httpClient.BaseAddress = new Uri("https://api.open-meteo.com");
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
          

            var response = await _httpClient.GetAsync(
               $"v1/forecast?latitude="+latitude.ToString().Replace(',', '.')+"&longitude=" + longitude.ToString().Replace(',', '.') + "&current_weather=true");
            var responseContent = await response.Content.ReadAsStringAsync();

            string result = JsonConvert.DeserializeObject<ResponseBody>(responseContent).ToString();
            Console.WriteLine(result);
            return result;
        }

        class ResponseBody
        {

            [JsonProperty("current_weather")]
            public ResponseBodyInner Info { get; set; }

            public override string ToString()
            {
                return $"OpenMeteo || Temp C: {Info.TempC}, WindSpeed: {Info.WindSpeed}";
            }
        }
        class ResponseBodyInner
        {
            [JsonProperty("temperature")]
            public double TempC { get; set; }

            [JsonProperty("windspeed")]
            public double WindSpeed { get; set; }
        }
    }
}
