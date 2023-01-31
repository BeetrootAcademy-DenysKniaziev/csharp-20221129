using System.Diagnostics;
using System.Threading.Tasks;

namespace Lesson23.Classwork
{
    internal class Program
    {
        static async void Main(string[] args)
        {
            var cts = new CancellationTokenSource();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            var tasks = new List<Task>();

            for (int i = 0; i < 100; i++)
            {
                var x = i;
                tasks.Add(Print(x.ToString(), cts.Token));
            }

            Task.Run(async () =>
            {
                await Task.Delay(1800);
                cts.Cancel();
            });

            Task.WaitAll(tasks.ToArray(), 10000);

            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            await GetNumber();
        }

        static async Task Print(string text, CancellationToken token)
        {
            Console.WriteLine("TID: " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(TimeSpan.FromSeconds(2));

            if (token.IsCancellationRequested)
                return;

            Console.WriteLine(text);

            if (token.IsCancellationRequested)
                return;

            await Task.Delay(TimeSpan.FromSeconds(2));
        }

        static async Task<int> GetNumberAsync()
        {
            await Task.Delay(1000);
            return 10;
        }

        static ValueTask<int> GetNumber()
        {
            return ValueTask.FromResult(10);
        }
    }
}