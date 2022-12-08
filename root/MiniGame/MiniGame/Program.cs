using System;

namespace MiniGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int level = 0;
            string password;
            string playerName;
            string input;

            Random rnd = new Random();

            string[] Level1Password = { "000", "001", "002", "003", "004" };
            string[] Level2Password = { "123", "456", "567", "789", "678" };
            string[] Level3Password = { "981", "845", "490", "612", "090" };

                Console.WriteLine("Привіт! Як тебе звуть?..");
                playerName = Console.ReadLine();

                Console.WriteLine("\n"+ playerName + ", тебе прийняли в Армію ворів!");

                Console.WriteLine("\nЯкий із 3 сейфів, створених легендарним Гансом Вагнером взломаємо?");
                Console.WriteLine("\n1 - Золото Рейна");
                Console.WriteLine("2 - Секрет");
                Console.WriteLine("3 - Валькірія");
                Console.WriteLine("\nЗробіть вибір ...");

                level = Convert.ToInt32(Console.ReadLine());

                switch (level)

                {
                    case 1:
                        password = Level1Password[rnd.Next(0, Level1Password.Length)];
                        Console.WriteLine("\nВгадайте пароль від сейфу Золото Рейна");
                    Console.WriteLine(password + " PASSWORD");
                    break;
                    case 2:
                        password = Level2Password[rnd.Next(0, Level2Password.Length)];
                        Console.WriteLine("\nВгадайте пароль від сейфу Секрет");
                    Console.WriteLine(password + " PASSWORD");
                    break;
                    case 3:
                        password = Level3Password[rnd.Next(0, Level3Password.Length)];
                        Console.WriteLine("\nВгадайте пароль від сейфу Валькірія");
                    Console.WriteLine(password + " PASSWORD");
                    break;
                    default:
                        Console.WriteLine("\nТакого рівня не існує");
                    password = null;
                    break;

                    
                }


                Console.WriteLine("\nВведіть пароль: *** . У вас 5 спроб.");

        for (int i = 0; i < 5; i++)
           {
                input = Console.ReadLine();

                if (input != password)
                {
                    Console.WriteLine("\nУпс. Спробуйте ще раз. Залишилось " + (5 - (i+1)) + "спроб. ");
                }

                else
                {
                    switch (level)
                    {
                        case 1:
                            Console.WriteLine("\nУра!");
                            Console.WriteLine(@"      
     * * * *              
* * * \|O|/ * * *   
 \o\o\o|O|o/o/o/      
 (<><><>O<><><>)     
 '============='  ");
                            break;

                        case 2:
                            Console.WriteLine("\nУра!");
                            Console.WriteLine(@"
 ________________________
|.----------------------.|
||                      ||
||       ______         ||
||     .;;;;;;;;.       ||
||    /;;;;;;;;;;;\     ||
||   /;/`    `-;;;;; . .||
||   |;|__  __  \;;;|   ||
||.-.|;| e`/e`  |;;;|   ||
||   |;|  |     |;;;|'--||
||   |;|  '-    |;;;|   ||
||   |;;\ --'  /|;;;|   ||
||   |;;;;;---'\|;;;|   ||
||   |;;;;|     |;;;|   ||
||   |;;.-'     |;;;|   ||
||'--|/`        |;;;|--.||
||;;;;    .     ;;;;.\;;||
||;;;;;-.;_    /.-;;;;;;||
||;;;;;;;;;;;;;;;;;;;;;;||
||jgs;;;;;;;;;;;;;;;;;;;||
'------------------------' ");
                            break;

                        case 3:
                            Console.WriteLine("\nУра!");
                            Console.WriteLine(@"
    %%%
   =====
  &%&%%%&
  %&  % 
   &\__/
    \ |____
   .', ,  ()
  / -.  _)| 
 |_(_.    |
 '-'\  )  |
     )    |");
                            break;
                    }
                }


            }


        }
    }
}
