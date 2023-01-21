#region NoLINQ

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//// створюємо новий список для результатів
//var selectedPeople = new List<string>();
//// проходимо масивом
//foreach (string person in people)
//{
//    // якщо рядок починається на букву T, додаємо до списку
//    if (person.ToUpper().StartsWith("T"))
//        selectedPeople.Add(person);
//}
//// сортуємо список
//selectedPeople.Sort();

//foreach (string person in selectedPeople)
//    Console.WriteLine(person);

#endregion

#region QueryLINQ

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//// створюємо новий список для результатів
//var selectedPeople = from p in people // передаємо кожен елемент з people в змінну p
//                     where p.ToUpper().StartsWith("T") //фільтрація за критерієм
//                     orderby p // впорядковуємо за зростанням
//                     select p; // вибираємо об'єкт у створювану колекцію

////selectedPeople.ToList().ForEach(Console.WriteLine);

//foreach (string person in selectedPeople)
//    Console.WriteLine(person);

#endregion

#region ExtensionsLINQ

//string[] people = { "Tom", "Bob", "Sam", "Tim", "Tomas", "Bill" };

//var selectedPeople = people.Where(p => p.ToUpper().StartsWith("T")).OrderBy(p => p);

//foreach (string person in selectedPeople)
//    Console.WriteLine(person);

#endregion

#region Select

//using Demo.Models;

//var people = new List<Person>
//{
//    new Person ("Tom", 23),
//    new Person ("Bob", 27),
//    new Person ("Sam", 29),
//    new Person("Mike", 32)
//};

#region Ex1

////var names = from p in people select p.Name;
//var names = people.Select(p => p.Name);

//foreach (var n in names)
//    Console.WriteLine(n);

#endregion

#region Ex2

////var employees = from p in people
////                select new
////                {
////                    FirstName = p.Name,
////                    Year = DateTime.Now.Year - p.Age
////                };

//var employees = people.Select(p => new
//{
//    FirstName = p.Name,
//    Year = DateTime.Now.Year - p.Age
//});

//foreach (var e in employees)
//    Console.WriteLine($"{e.FirstName} - {e.Year}");

#endregion

#region Ex3

//var employees = from p in people
//                let name = $"Mr. {p.Name}"
//                let year = DateTime.Now.Year - p.Age
//                select new
//                {
//                    Name = name,
//                    Year = year,

//                };

//foreach (var e in employees)
//    Console.WriteLine($"{e.Name} - {e.Year}");

#endregion

#region Ex4

//var courses = new List<Course> { new Course("C#"), new Course("Java") };
//var students = new List<Student> { new Student("Tom"), new Student("Bob") };

////var enrollments = from course in courses
////                  from student in students
////                  select new { Student = student.Name, Course = course.Title };

//var enrollments = courses.SelectMany(c => students.Select(s => new { Student = s.Name, Course = c.Title }));

//foreach (var enrollment in enrollments)
//    Console.WriteLine($"{enrollment.Student} - {enrollment.Course}");

#endregion

#region Ex5

//var companies = new List<Company>
//{
//    new Company("Microsoft", new List<Person> {new Person("Tom", 23), new Person("Bob", 27)}),
//    new Company("Google", new List<Person> {new Person("Sam", 29), new Person("Mike", 32)}),
//};

////var employees = from c in companies
////                from emp in c.Staff
////                select emp;

//var employees = companies.SelectMany(c => c.Staff);

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name}");

#endregion

#region Ex6

////var employees = from c in companies
////                from emp in c.Staff
////                select new { Name = emp.Name, Company = c.Name };

//var employees = companies.SelectMany(c => c.Staff,
//                                    (c, emp) => new { Name = emp.Name, Company = c.Name });

//foreach (var emp in employees)
//    Console.WriteLine($"{emp.Name} - {emp.Company}");

#endregion

#region Tasks

//var customers = new List<Customer>
//{
//    new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
//    new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
//    new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
//    new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
//};

//Завдання 1: Вивести імена та вік клієнтів
//Завдання 2: Вивести всі телефонні номери клієнтів з кодом +380
//Завдання 3: Вивести всі телефонні номери з інформацією про клієнта для кожного номеру

#endregion

#endregion

#region Where

using Demo.Models;

var people = new List<Person>
{
    new Person ("Tom", 23),
    new Person ("Bob", 27),
    new Person ("Sam", 29),
    new Person("Mike", 32),
    new Person("Nike", 32)
};

#region Ex1

//string[] names = { "Tom", "Alice", "Bob", "Sam", "Tim", "Tomas", "Bill" };

////var selectedNames = from n in names
////                    where n.Length == 3
////                    select n;

//var selectedNames = names.Where(n => n.Length == 3);

//foreach (string name in selectedNames)
//    Console.WriteLine(name);

#endregion

#region Ex2

//int[] numbers = { 1, 2, 3, 4, 10, 34, 55, 66, 77, 88 };

////var evens = from i in numbers
////            where i % 2 == 0 && i > 10
////            select i;

//var evens = numbers.Where(i => i % 2 == 0 && i > 10);

//foreach (var number in evens)
//    Console.WriteLine(number);

#endregion

#region Ex3

//var selectedPeople = from p in people
//                     where p.Age > 25
//                     select p;

////var selectedPeople = people.Where(p => p.Age > 25);

//foreach (Person person in selectedPeople)
//    Console.WriteLine($"{person.Name} - {person.Age}");

#endregion

#region Ex4

var teachers = new List<Teacher>
{
    new Teacher ("Tom", 31, new List<string> {"english", "german"}),
    new Teacher ("Bob", 27, new List<string> {"english", "french" }),
    new Teacher ("Sam", 29, new List<string>  { "english", "spanish" }),
    new Teacher ("Alice", 44, new List<string> {"spanish", "german" })
};

////var selectedTeachers = from teacher in teachers
////                       from lang in teacher.Languages
////                       where teacher.Age > 28
////                       where lang == "english"
////                       select teacher;

var selectedTeachers = teachers.SelectMany(t => t.Languages,
                            (t, l) => new { Teacher = t, Lang = l })
                          .Where(x => x.Lang == "english" && x.Teacher.Age > 28)
                          .Select(x => x.Teacher);

//foreach (Teacher teacher in selectedTeachers)
//    Console.WriteLine($"{teacher.Name} - {teacher.Age} - {string.Join(',', teacher.Languages)}");

#endregion

#region Tasks

var customers = new List<Customer>
{
    new Customer("Alice", new DateTime(1992, 7, 2), new List<string> {"671954099", "671786544", "675098430"}),
    new Customer("Nick", new DateTime(1984, 1, 15), new List<string> {"672577324", "671098897"}),
    new Customer("Ben", new DateTime(1983, 9, 23), new List<string> {"673555431"}),
    new Customer("Sarah", new DateTime(1990, 2, 6), new List<string> {"671675380", "672135768", "672121655"})
};

//Завдання 1: Вивести інформацією про клієнтів, хто народився у січні
//Завдання 2: Вивести інформацією про клієнтів, імена яких мають непарну довжину
//Завдання 3: Вивести інформацією про клієнтів, хто народилися у парному місяці року та хоча б один номер яких починається з "671"

#endregion

#endregion

#region OrderBy

#endregion

//foreach (var item in people.Reverse<Person>())
//{
//    Console.WriteLine(item);
//}

//foreach (var item in people.OrderByDescending(x => x.Age).ThenBy(x => x.Name))
//{
//    Console.WriteLine(item);
//}

foreach (var group in people.GroupBy(x => x.Age))
{
    Console.WriteLine("GROUP: " + group.Key);

    foreach (var item in group)
    {
        Console.WriteLine(item);
    }
}

 var b1 = people.Any(x => x.Age == 27);
Console.WriteLine(b1);

var b2 = people.All(x => x.Age == 27);
Console.WriteLine(b2);

Console.WriteLine(people.First(x => x.Age > 27));
Console.WriteLine(people.Last(x => x.Age > 27));
Console.WriteLine(people.Single(x => x.Age == 27));
Console.WriteLine();
foreach (var item in people.Take(3))
{
    Console.WriteLine(item);
}
Console.WriteLine();
foreach (var item in people.Skip(1))
{
    Console.WriteLine(item);
}
