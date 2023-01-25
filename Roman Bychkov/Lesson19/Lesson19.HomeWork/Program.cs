using Newtonsoft.Json;
using System.Diagnostics.CodeAnalysis;

public class Program
{

    public static void Main()
    {
        #region FIRST PART
        var customers = new List<Customer>
        {
            new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
            new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
            new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
            new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
        };

        //Завдання 1: Вивести імена та вік клієнтів
        Console.WriteLine("Task 1 START");
        var query11 = from c in customers
                      select new
                      {
                          Name = c.Name,
                          Age = GetAge(c.Birthday, DateTime.Now)
                      };
        foreach (var item in query11)
            Console.WriteLine($"Name: {item.Name} Age: {item.Age}");
        Console.WriteLine();
        var guery12 = customers.Select(c => new
        {
            Name = c.Name,
            Age = GetAge(c.Birthday, DateTime.Now)
        });
        foreach (var item in guery12)
            Console.WriteLine($"Name: {item.Name} Age: {item.Age}");
        Console.WriteLine("Task 1 END");

        //Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
        Console.WriteLine("Task 2 START");
        var query21 = from c in customers
                      from p in c.PhoneNumbers
                      select new
                      {
                          Phone = "+380" + p
                      };
        foreach (var item in query21)
            Console.WriteLine($"\t{item.Phone}");

        Console.WriteLine();

        var query22 = customers.SelectMany(c => c.PhoneNumbers).Select(x => "+380" + x);
        foreach (var item in query22)
            Console.WriteLine($"\t{item}");
        Console.WriteLine("Task 2 END");

        //Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру
        Console.WriteLine("Task 3 START");
        var query31 = from c in customers
                      from p in c.PhoneNumbers
                      select new
                      {
                          PhoneNumber = p,
                          Name = c.Name,
                          Birthday = c.Birthday
                      };
        foreach (var item in query31)
            Console.WriteLine($"{item.PhoneNumber} {item.Name} {item.Birthday}");

        Console.WriteLine();

        var query32 = customers.SelectMany(c => c.PhoneNumbers,
                                            (c, p) =>
                                            new
                                            {
                                                PhoneNumber = p,
                                                Name = c.Name,
                                                Birthday = c.Birthday
                                            });

        foreach (var item in query32)
            Console.WriteLine($"{item.PhoneNumber} {item.Name} {item.Birthday}");
        Console.WriteLine("Task 3 END");




        static int GetAge(DateTime d1, DateTime d2)
        {
            var r = d2.Year - d1.Year;
            return d1.AddYears(r) <= d2 ? r : r - 1;
        }


        //Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
        Console.WriteLine("Task 1 START");
        var quer11 = from c in customers
                     where c.Birthday.Month == 1
                     select c;
        foreach (var item in quer11)
            Console.WriteLine(item);

        Console.WriteLine();

        var quer12 = customers.Where(c => c.Birthday.Month == 1);
        foreach (var item in quer11)
            Console.WriteLine(item);
        Console.WriteLine();
        Console.WriteLine("Task 1 END");
        //Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
        Console.WriteLine("Task 2 START");
        var quer21 = from c in customers
                     where c.Name.Length % 2 != 0
                     select c;
        foreach (var item in quer21)
            Console.WriteLine(item);

        Console.WriteLine();

        var quer22 = customers.Where(c => c.Name.Length % 2 != 0);
        foreach (var item in quer22)
            Console.WriteLine(item);
        Console.WriteLine();
        Console.WriteLine("Task 2 END");

        //Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з "671"

        Console.WriteLine("Task 3 START");
        var quer31 = from c in customers
                     where c.Birthday.Month % 2 == 0 && c.PhoneNumbers.Any(x => x.StartsWith("671"))
                     select c;
        foreach (var item in quer31)
        {
            Console.WriteLine(item);
            foreach (var item2 in item.PhoneNumbers)
                Console.WriteLine("\t" + item2);
        }

        Console.WriteLine();

        var quer32 = customers.Where(c => c.Birthday.Month % 2 == 0 && c.PhoneNumbers.Any(x => x.StartsWith("671")));
        foreach (var item in quer32)
        {
            Console.WriteLine(item);
            foreach (var item2 in item.PhoneNumbers)
                Console.WriteLine("\t" + item2);
        }
        Console.WriteLine();
        Console.WriteLine("Task 3 END");
        #endregion
        #region SECOND PART
        var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

        //find out who is located farthest north/south/west/east using latitude/longitude data
        var north = persons.FirstOrDefault(p => p.Latitude == persons.Max(p => p.Latitude));
        var south = persons.FirstOrDefault(p => p.Latitude == persons.Min(p => p.Latitude));
        var east = persons.FirstOrDefault(p => p.Longitude == persons.Min(p => p.Longitude));
        var west = persons.FirstOrDefault(p => p.Longitude == persons.Max(p => p.Longitude));
        Console.WriteLine($"North: {north.Name}, South: {south.Name}, East: {east.Name}, West: {west.Name}");
        //find max and min distance between 2 persons

        var resulst = from p1 in persons
                      from p2 in persons.SkipWhile(p => p != p1).Skip(1)
                      select new
                      {
                          distance = FindDistance(p1.Longitude, p1.Latitude, p2.Longitude, p2.Latitude)
                      };

        Console.WriteLine($"Result Max dist: {resulst.Max(p => p.distance)} ");
        Console.WriteLine($"Result Min dist: {resulst.Min(p => p.distance)} ");
        //find 2 persons whos ‘about’ have the most same words

        var result3 = (from p1 in persons
                       from p2 in persons.SkipWhile(p => p != p1).Skip(1)
                       select new
                       {
                           Person1 = p1,
                           Person2 = p2,
                           CountOfWords = p1.About.ToLower().Replace(".", String.Empty).Split(new char[] { ' ' })
                           .Intersect
                           (p2.About.ToLower().Replace(".", String.Empty).Split(new char[] { ' ' })).Count()

                       }).OrderByDescending(p => p.CountOfWords).FirstOrDefault();


        Console.WriteLine($"{result3.Person1.Name} has the {result3.CountOfWords} same words with {result3.Person2.Name}");

        //find persons with same friends(compare by friend’s name)
        //LINQ
        Console.WriteLine("Linq");
        var result4 = from p1 in persons
                      from p2 in persons.SkipWhile(p => p != p1).Skip(1)
                      let countOfFriends = p1.Friends.Intersect(p2.Friends, new FriendComparer()).Count()
                      where countOfFriends > 0
                      select new
                      {
                          Person1 = p1,
                          Person2 = p2,
                          CountOfFriends = countOfFriends
                      };
        foreach (var f in result4)
            Console.WriteLine($"{f.Person1.Name} has same friends with {f.Person2.Name}");

        //EXTENSION
        Console.WriteLine("Extension");
        var result41 = persons.Select(p => persons.SkipWhile(p1 => p1 != p).Skip(1)
        .Where(p1 => p1.Friends.Intersect(p.Friends, new FriendComparer()).Count() > 0)
        .Select(p1 => new
        {
            Person1 = p,
            Person2 = p1,
            CountOfFriends = p1.Friends.Intersect(p.Friends, new FriendComparer()).Count()
        }));
        foreach (var f in result41)
            foreach(var p in f)
            Console.WriteLine($"{p.Person1.Name} has same friends with {p.Person2.Name}");


        #endregion
        double FindDistance(double x1, double y1, double x2, double y2) => Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));

    }
    public class FriendComparer : IEqualityComparer<Friend>
    {
        public bool Equals(Friend? p1, Friend? p2)
        {
            if (p1 is null || p2 is null) return false;
            return p1.Name == p2.Name;
        }

        public int GetHashCode([DisallowNull] Friend obj)
        {
            return obj.Name.GetHashCode();
        }
    }
    record class Customer(string Name, DateTime Birthday, List<string> PhoneNumbers);


}


