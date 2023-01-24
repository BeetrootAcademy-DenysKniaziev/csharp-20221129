using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LinqLesson
{
    class Program
    {
        record class Customer(string Name, DateTime Birthday, List<string> PhoneNumbers);

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
                new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
                new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
                new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
            };

            //SELECT
            //Завдання 1: Вивести імена та вік клієнтів
            //Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
            //Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру

            //WHERE:
            //Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
            //Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
            //Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з "671"

            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //find out who is located farthest north/south/west/east using latitude/longitude data
            //find max and min distance between 2 persons
            //find 2 persons whos ‘about’ have the most same words
            //find persons with same friends(compare by friend’s name)            
        }
    }
}
