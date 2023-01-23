#region Tasks

using Demo.Models;

var customers1 = new List<Customer>
{
    new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
    new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
    new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
    new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
};

//Завдання 1: Вивести імена та вік клієнтів
Console.WriteLine("Task 1 START");
var query11 = from c in customers1
              select new
              {
                  Name = c.Name,
                  Age = GetAge(c.Birthday, DateTime.Now)
              };
foreach (var item in query11)
    Console.WriteLine($"Name: {item.Name} Age: {item.Age}");
Console.WriteLine();
var guery12 = customers1.Select(c => new
{
    Name = c.Name,
    Age = GetAge(c.Birthday, DateTime.Now)
});
foreach (var item in guery12)
    Console.WriteLine($"Name: {item.Name} Age: {item.Age}");
Console.WriteLine("Task 1 END");

//Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
Console.WriteLine("Task 2 START");
var query21 = from c in customers1
              from p in c.PhoneNumbers
              select new
              {
                  Phone = "+380" + p
              };
foreach (var item in query21)
    Console.WriteLine($"\t{item.Phone}");

Console.WriteLine();

var query22 = customers1.SelectMany(c => c.PhoneNumbers).Select(x => "+380" + x);
foreach (var item in query22)
    Console.WriteLine($"\t{item}");
Console.WriteLine("Task 2 END");

//Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру
Console.WriteLine("Task 3 START");
var query31 = from c in customers1
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

var query32 = customers1.SelectMany(c => c.PhoneNumbers,
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

#endregion


static int GetAge(DateTime d1, DateTime d2)
{
    var r = d2.Year - d1.Year;
    return d1.AddYears(r) <= d2 ? r : r - 1;
}

#region Tasks

var customers = new List<Customer>
{
    new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
    new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
    new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
    new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
};

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


