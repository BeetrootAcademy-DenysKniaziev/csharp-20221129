using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace Lesson23.HomeWork
{
    internal class MicroWeatherAPI
    {
        private string _token;
       
        public MicroWeatherAPI(string token)
        {
            _token = token;
        }
        public async Task<string> CreateRequestAsync(string city)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.m3o.com");
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var _body = new RequestBody
            {
                Location = city,
            };
            var response = await httpClient.PostAsync(
               "v1/weather/Now",
               new StringContent(JsonConvert.SerializeObject(_body), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            string result = JsonConvert.DeserializeObject<ResponseBody>(responseContent).ToString();
            Console.WriteLine(result);
            return result;

        }
        public async Task<LatitudeLongitude> GetLatitudeLongitude(string city)
        {
            using var httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://api.m3o.com");
            httpClient.Timeout = TimeSpan.FromSeconds(10);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);

            var _body = new RequestBody
            {
                Location = city,
            };
            var response = await httpClient.PostAsync(
               "v1/weather/Now",
               new StringContent(JsonConvert.SerializeObject(_body), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<LatitudeLongitude>(responseContent);

        }


        class RequestBody
        {
            [JsonProperty("location")]
            public string Location { get; set; }
        }
        class ResponseBody
        {
            [JsonProperty("region")]
            public string Region { get; set; }

            [JsonProperty("temp_c")]
            public double TempC { get; set; }

            [JsonProperty("feels_like_c")]
            public double FeelsLikeC { get; set; }

            [JsonProperty("cloud")]
            public double Cloud { get; set; }

            [JsonProperty("condition")]
            public string Condition { get; set; }

            public override string ToString()
            {
                return $"MicroWeather || Region : {Region}, Temp C: {TempC}, Feels Like: {FeelsLikeC}, Cloud: {Cloud}, Condition: {Condition}";
            }
        }
        public class LatitudeLongitude
        {
            [JsonProperty("latitude")]
            public double Latitude { get; set; }

            [JsonProperty("longitude")]
            public double Longitude { get; set; }
            public override string ToString()
            {
                return $"Latitude : {Latitude}, Longitude : {Longitude}";
            }
        }

    }
}
