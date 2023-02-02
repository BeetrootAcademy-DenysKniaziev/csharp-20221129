using Lesson23.HomeWork;
using Lesson23.HomeWork.API;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;
using static Lesson23.HomeWork.MicroWeatherAPI;

class Program
{

    static async Task Main()
    {
      
        var microWeatherClient = new MicroWeatherAPI();
        var openMeteoClient = new OpenMeteoAPI();
        var OpenWeather = new OpenWeatherAPI();
        LatitudeLongitude coordinateCity;
        string cityName;

        while (true)
        {
            Console.WriteLine("Enter city name:");
            cityName = Console.ReadLine();
            coordinateCity = await microWeatherClient.GetLatitudeLongitude(cityName);
            Console.WriteLine();
          
            var task1 = microWeatherClient.CreateRequestAsync(cityName);
            var task2 = openMeteoClient.CreateRequestAsync(coordinateCity.Latitude, coordinateCity.Longitude);
            var task3 = OpenWeather.CreateRequestAsync(coordinateCity.Latitude, coordinateCity.Longitude);

            var allTasks = Task.WhenAll(task1, task2, task3);

            try
            {
                await allTasks;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                Console.WriteLine($"IsFaulted: {allTasks.IsFaulted}");
                if (allTasks.Exception is not null)
                {
                    foreach (var exception in allTasks.Exception.InnerExceptions)
                    {
                        Console.WriteLine($"InnerException: {exception.Message}");
                    }
                }
            }
            Console.WriteLine();
        }
    }
}