using Lesson23;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Windows.Forms;

namespace Homework23
{

    public class Result
    {
        public List<Tag> tags { get; set; }
    }

    public class Root
    {
        public Result result { get; set; }
        public Status status { get; set; }
    }

    public class Status
    {
        public string text { get; set; }
        public string type { get; set; }
    }

    public class Tag
    {
        public double confidence { get; set; }
        public Tag2 tag { get; set; }
    }

    public class Tag2
    {
        public string en { get; set; }
    }
    internal class ImageToText
    {
        public static string ConvertImageToText(string imageUrl)
        {
            // fileName = "https://imagga.com/static/images/tagging/wind-farm-538576_640.jpg";

            string apiKey = "acc_3407d769a837da1";
            string apiSecret = "eca9b760cf4df75010bfcee655cf1b67";
            //string imageUrl = "https://imagga.com/static/images/tagging/wind-farm-538576_640.jpg";

            string basicAuthValue = System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(String.Format("{0}:{1}", apiKey, apiSecret)));

            var client = new RestClient("https://api.imagga.com/v2/tags");

            var request = new RestRequest();
            request.AddParameter("image_url", imageUrl);
            request.AddHeader("Authorization", String.Format("Basic {0}", basicAuthValue));

            var response = client.Execute(request);

            var json = Newtonsoft.Json.JsonConvert.DeserializeObject(response.Content);
            var goodLookingResponce = JsonConvert.SerializeObject(json, Formatting.Indented);

            System.IO.File.WriteAllText("prediction.json", goodLookingResponce);
            var root = JsonConvert.DeserializeObject<Root>(goodLookingResponce);

            var InImage = root.result.tags.Select(t => new { tag = t.tag.en, confidence = t.confidence }).Where(c => c.confidence > 35);
            //Console.WriteLine(goodLookingResponce);
            var autoRequest = "";
            Console.WriteLine(imageUrl + "\nOne AI Saw on the picture:");
            foreach (var i in InImage)
            {
                var rnd = new Random().Next(0,3);
                if (rnd == 1)
                {
                    autoRequest += i.tag + ", ";
                    Console.WriteLine("- " + i.tag + " " + (int)i.confidence + "%");
                }
            }
            if (autoRequest == "") autoRequest = "empty";
            Console.WriteLine("Another AI Drawing Based On This...\n");
            //Console.ReadLine();
            return autoRequest;
        }
    }
}
