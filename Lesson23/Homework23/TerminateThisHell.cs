using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework23
{
    internal class TerminateThisHell
    {
        public static void StopAll() 
        {
            while (true)
            {
                var k = Console.ReadKey();
                if (k.Key == ConsoleKey.D0) Environment.Exit(1);
            }
        }
    }
}
