using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;

namespace Lesson23.Homework
{
    internal class TextToImage
    {

        class RequestBody
        {
            [JsonProperty("prompt")]
            public string Request { get; set; }

            [JsonProperty("n")]
            public int ImagesNumber { get; set; }

            [JsonProperty("size")]
            public string ImagesSize { get; set; }

            [JsonProperty("response_format")]
            public string Format { get; set; }
        }

        class ResponseBody
        {
            public class DataItems
            {
                [JsonProperty("url")]
                public string Url { get; set; }
            }

            [JsonProperty("created")]
            public long Created { get; set; }

            [JsonProperty("data")]
            public List<DataItems> Data { get; set; }
        }

        public static async Task ConvertTextToImage(string request)
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://api.openai.com"),
                Timeout = TimeSpan.FromSeconds(100),

            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "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");

            //Console.WriteLine("Image Description:");
            //var request = Console.ReadLine();

            var body = new RequestBody
            {
                Request = request,
                ImagesNumber = 1,
                ImagesSize = "1024x1024",
                Format = "url"
            };

            var response = await client.PostAsync(
                "v1/images/generations",
                new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"));

            var responseContent = await response.Content.ReadAsStringAsync();
            var responseBody = JsonConvert.DeserializeObject<ResponseBody>(responseContent);

            using var imageClient = new HttpClient();

            for (int i = 0; i < responseBody.Data.Count; i++)
            {
                var data = responseBody.Data[i];
                var imageResponse = await imageClient.GetAsync(data.Url);
                var imageBytes = await imageResponse.Content.ReadAsByteArrayAsync();
                File.WriteAllBytes($"img{i}.jpg", imageBytes);
                Process.Start("explorer.exe", $"img{i}.jpg");
            }
        }
    }
}


