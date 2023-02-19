
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using static System.Console;

namespace Homework19
{
    class Program
    {
        record class Customer( string Name, DateTime Birthday, List<string> PhoneNumbers);

        static void Main(string[] args)
        {
            var customers = new List<Customer>
            {
                new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
                new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
                new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
                new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "67135768", "672121655"})
            };

            //SELECT
            //Завдання 1: Вивести імена та вік клієнтів
            var names1 = from cust in customers
                         select new
                         {
                             name = cust.Name
                         };
            var names2 = customers.Select(cust => cust.Name);

            WriteLine("Names and ages of clients\n Query method");
            names1.ToList().ForEach(n => WriteLine(n.name));
            names1.ToList().ForEach(n => WriteLine(n)); //to understend differance
            WriteLine("Inline method");
            names2.ToList().ForEach(n => WriteLine(n));

            //Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380

            WriteLine("Telephone numbers:\nInline method");
            var numbers2 = customers.Select(n => n.PhoneNumbers).SelectMany(all => all);//.ToList().ForEach(nums => nums.ForEach(num => WriteLine("380" + num)));//.ForEach(num => WriteLine(num));
            numbers2.ToList().ForEach(ns => WriteLine("+380" + ns));

            WriteLine();
            var numbers1 = from cust in customers
                           select new
                           {
                               numbs = cust.PhoneNumbers
                           };
            WriteLine("Query method");
            numbers1.ToList().ForEach(ns => ns.numbs.ForEach(n => WriteLine("+380" + n)));

            //Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру
            var cn6 = customers.Select(s => new { numbers = s.PhoneNumbers.ToList(), name = s.Name });
            var cn7 = from cust in customers
                      select new
                      {
                          numbers = cust.PhoneNumbers.ToList(),
                          name = cust.Name
                      };


            //var cn1 = customers.SelectMany(c => c.Name, customers.Select(n => n.PhoneNumbers).SelectMany(all => all));
            WriteLine("\nNumbers and clients\nInline method");
            foreach (var t in cn6)
                foreach (var tt in t.numbers) WriteLine(tt + "  " + t.name);
            WriteLine("Query method");
            foreach (var item in cn7)
                item.numbers.ToList().ForEach(text => WriteLine(item.name + " " + text));

            //WHERE:
            //Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
            var jenuaries1 = customers.Where(z => z.Birthday.Month == 1).Select(c => new { name = c.Name, birth = c.Birthday });
            WriteLine("\nBorn in Jenuary\nInline method");
            foreach (var jb in jenuaries1) WriteLine(jb.name + "  " + jb.birth.ToString());
            var jenuaries2 = from cust in customers
                             where cust.Birthday.Month == 1
                             select new
                             {
                                 name = cust.Name,
                                 birth = cust.Birthday.ToString()
                             };
            WriteLine("Query method");
            foreach (var jb in jenuaries2) WriteLine(jb.name + "  " + jb.birth.ToString());


            //Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
            var oddnames1 = customers.Where(z => z.Name.Count() % 2 != 0).Select(c => new { name = c.Name });
            WriteLine("\nClients with not odd name lenght\nInline method");
            foreach (var od in oddnames1) WriteLine(od.name);

            var oddnames2 = from cust in customers
                            where cust.Name.Count() % 2 != 0
                            select new
                            {
                                name = cust.Name,
                            };
            WriteLine("Query method");
            foreach (var od in oddnames2) WriteLine(od.name);

            //Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з "671"

            WriteLine("\nЗавдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з \"671");

            var cl1 = customers.Where(cust => cust.PhoneNumbers.Any(x => x.StartsWith("671"))).Where(cust => cust.Birthday.Month % 2 == 0);
            var cl2 = from cust in customers
                          //from ph in cust.PhoneNumbers
                          //where ph.StartsWith("671") == true
                      where cust.PhoneNumbers.Any(x => x.StartsWith("671"))
                      where cust.Birthday.Month % 2 == 0 //&& cust.PhoneNumbers.Select(num => num.StartsWith("671")).Count() > 0
                      select new
                      {
                          name = cust.Name
                      };
            WriteLine("Inline method");
            foreach (var i in cl1)
                WriteLine("- " + i.Name);
            WriteLine("Query method");
            foreach (var i in cl2)
                WriteLine("- " + i.name);



            var persons = JsonConvert.DeserializeObject<IEnumerable<Person>>(File.ReadAllText("data.json"));

            //File.WriteAllText("data2.json", JsonConvert.SerializeObject(persons,Formatting.Indented));

            //find out who is located farthest north/south/west/east using latitude/longitude data
            var south1 = persons.Where(p => p.Latitude == persons.Select(d => d.Latitude).Min() || p.Latitude == persons.Select(d => d.Latitude).Max() || p.Longitude == persons.Select(d => d.Longitude).Max() || p.Longitude == persons.Select(d => d.Longitude).Min()).Select(p => new { name = p.Name, limX = p.Latitude, limY = p.Longitude });

            var south2 = from p in persons
                         where p.Latitude == persons.Select(d => d.Latitude).Min() || p.Latitude == persons.Select(d => d.Latitude).Max() || p.Longitude == persons.Select(d => d.Longitude).Max() || p.Longitude == persons.Select(d => d.Longitude).Min()
                         select new
                         {
                             name = p.Name,
                             limX = p.Latitude,
                             limY = p.Longitude
                         };

            WriteLine("\nPeople that located farthest\nInline method");
            foreach (var s in south1) WriteLine(s.name + " Lat:" + s.limX + " Long:" + s.limY);
            WriteLine("\nQuery method");
            foreach (var s in south2) WriteLine(s.name + " Lat:" + s.limX + " Long:" + s.limY);

            //find max and min distance between 2 persons
            //Person p2 = new();
            var maxDistance1 = (from p1 in persons
                                from p2 in persons
                                select p2.Position(p1)).Max();

            var minDistance1 = (from p1 in persons
                                from p2 in persons
                                let d = p2.Position(p1)
                                where d != 0
                                select d).Min();

            var maxDistance2 = (persons.Select(p1 => persons.Select(p2 => p2.Position(p1)).Max())).Max();
            var minDistance2 = persons.Select(p1 => persons.Select(p2 => new { dist = p2.Position(p1), name1 = p1.Name, name2 = p2.Name }).Where(g => g.dist != 0).Min(x => x.dist)).Min();


            WriteLine("\n Querry method\nLongest distance through earth core is " + maxDistance1 * 6365 + " km\n"
                + "Shortest distance through earth core is " + minDistance1 * 6365 + " km");//.name1 + "  " + d.name2+"  "+ d.dist);
            WriteLine();
            WriteLine(" Inline method\nLongest distance through earth core is " + maxDistance2 * 6365 + " km\n"
                + "Shortest distance through earth core is " + minDistance2 * 6365 + " km");

            WriteLine("\nCalculating...");


            //find 2 persons whos ‘about’ have the most same words
            var simWords1 = (from p1 in persons
                             from p2 in persons
                             let w1 = p1.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')
                             let w2 = p2.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')
                             //where w2.Intersect(w1).Count() > 0
                             where p1.Name != p2.Name
                             select new
                             {
                                 name1 = p1.Name,
                                 name2 = p2.Name,
                                 intersections = w2.Intersect(w1),
                                 //iCount = w2.Intersect(w1).Count()
                             }).OrderByDescending(x => x.intersections.Count());

            //var simWords2 = persons.Select(p1 => persons.Select(p2 => p1.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')
            //.Intersect(p2.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')).Select(e => new { name1 = p1.Name, name2 = p2.Name, intersections = p1.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')
            //.Intersect(p2.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')) }).OrderByDescending(x => x.intersections.Count())));
            //.Where(h => p1.Name != p2.Name)

            WriteLine();
            WriteLine("Most similare 'about' have " + simWords1.ToList()[0].name1 + " and " + simWords1.ToList()[0].name2 + " with " + simWords1.ToList()[0].intersections.Count() + " words. The similar words is:\n");
            simWords1.ToList()[0].intersections.ToList().ForEach(j => WriteLine(j));

            //find persons with same friends(compare by friend’s name)

            var sameFriends1 = (from p1 in persons
                                from p2 in persons
                                where p1.Name != p2.Name
                                let f1 = p1.Friends.Select(o => o.Name)// .About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')
                                let f2 = p2.Friends.Select(o => o.Name)//.About.ToUpper().Split(' ', ',', '.', ':', ';', '\t')
                                let inter = f2.Intersect(f1)
                                where inter.Count() > 0

                                select new
                                {
                                    name1 = p1.Name,
                                    name2 = p2.Name,
                                    intersections = inter,
                                    iCount = inter.Count()
                                });

            var sameFriends2 = persons.Select(p1 => persons.Select(p2 => new
            {   name1 = p1.Name,  name2 = p2.Name,  intersections = p1.Friends.Select(o => o.Name).Intersect(p2.Friends.Select(o => o.Name)
            .Where(h => p1.Name != p2.Name ))}));

            if (sameFriends1.Count() > 0)
                foreach (var s in sameFriends1) WriteLine(s.name1 + " have friends same to  " + s.name2 + ". Number of same friends is " + s.iCount);
            else WriteLine("No persones with same friends");
        }

    }
}