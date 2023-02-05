using System.Runtime.Intrinsics.X86;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Text;
using Lesson23.Homework;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using System.Net.Http;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

//Use any API to request data and return it to the user in user readable form
//Extra:
//Use several APIs to request data, e.g. user inputs data, application requests it’s geolocation and returns weather in current geolocation

namespace Lesson23
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://imagga.com/static/images/tagging/wind-farm-538576_640.jpg";
            Console.WriteLine("While you waiting, please enjoy the music\nTo stop program press '0'\n");

            Thread Meanwhile = new Thread(Homework23.Entertament.MusicPlay);
            Meanwhile.Start();
            Thread WaitingForTermination = new Thread(Homework23.TerminateThisHell.StopAll);
            WaitingForTermination.Start();

            for (int i = 0; i < 3; i++)
            {
                // Recognizing Image and write text tags that will be seted as task 
                var autoRequest = Homework23.ImageToText.ConvertImageToText(url);
                await Lesson23.Homework.TextToImage.ConvertTextToImage(autoRequest);
            }
            Console.WriteLine("You can proceede enjoing music or press '0' to exit");
        }


    }
}