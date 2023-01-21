//                 Завдання із практичної у моєму коледжі
// Створити масив Група із 10 елементів Студент, що представлений структурою.
// Структура Студент має містити інформацію про прізвище, ім’я студента, дату народження,
//                                                      місце проживання (місто/область).
// Вивести інформацію про усіх студентів, що народились влітку.
// Обчислити, скільки студентів мешкають в місті.

namespace Lesson14.Homework
{
    public interface ICanStudy
    {
        public void Study();
    }

    public struct Student : ICanStudy // структура не може наслідувати і наслідуватись (окрім як від класу object), але може реалізовувати інтерфейси
    {
        public string LastName { get; set; } // недоступний модифікатор protected, так як він працює із наслідуванням
        public string FirstName { get; set; }
        public DateTime BirthDate { get; set; }
        public string PlaceOfResident { get; set; }
        public Student(string lastName, string firstName, DateTime birthD, string placeOfRes)
        {
            LastName = lastName;
            FirstName = firstName;
            BirthDate = birthD;
            PlaceOfResident = placeOfRes;
        }

        public override string ToString() // можна переписувати методи класу object
        {
            return $"{LastName} {FirstName} | {BirthDate:dd.MM.yyyy} | {PlaceOfResident}";
        }

        public void Study()
        {
            Console.WriteLine("I study!");
        }

        public static Student[] operator +(Student firstStudent, Student secondStudent)
        {
            return new Student[] { firstStudent, secondStudent };
        }
    }

    internal class Program
    {
        // Цей випадок використання структур є небажаний, тому що при передавані структур як параметрів, вони витрачають в рази більше часу для виконання ніж класи
        public static void ShowSummerStudents(params Student[] students)
        {
            Console.WriteLine("Students who were born in the summer:");
            foreach (var student in students)
            {
                if (student.BirthDate.Month >= 6 && student.BirthDate.Month <= 8) Console.WriteLine($"{student.LastName} {student.FirstName} | {student.BirthDate:dd.MM.yyyy}");
            }
            Console.WriteLine();
        }
        public static void ShowCityStudents(params Student[] students)
        {
            Console.WriteLine("Students who were born in a city:");
            foreach (var student in students)
            {
                if (student.PlaceOfResident == "city") Console.WriteLine($"{student.LastName} {student.FirstName} | {student.PlaceOfResident}");
            }
            Console.WriteLine();
        }
        public static void ShowStudentsInfo(params Student[] students)
        {
            Console.WriteLine("Students information:");
            foreach (var student in students)
            {
                Console.WriteLine(student.ToString());
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            Student firstStudent = new Student("Bereziuk", "Bogdan", new DateTime(2003, 6, 3), "city");
            Student secondStudent = new Student("Glazacheva", "Olha", new DateTime(2003, 8, 28), "region");
            Student thirdStudent = new Student("Galkovich", "Nazar", new DateTime(2004, 5, 20), "region");
            Student fourthStudent = new Student("Ivankov", "Oleksiy", new DateTime(2002, 12, 9), "region");
            Student fifthStudent = new Student("Blazhkova", "Julia", new DateTime(1998, 1, 21), "city");

            Student sixthStudent = new Student("Sapozhnik", "Ruslana", new DateTime(1994, 11, 18), "region");
            Student seventhStudent = new Student("Blazhkov", "Viacheslav", new DateTime(2003, 8, 26), "region");
            Student eighthStudent = new Student("Zozulia", "Oleksandr", new DateTime(2003, 8, 23), "city");
            Student ninthStudent = new Student("Zhurian", "Maria", new DateTime(2006, 2, 7), "city");
            Student tenthStudent = new Student("Ragulska", "Ivanna", new DateTime(2003, 4, 4), "region");

            Student[] students = {firstStudent, secondStudent, thirdStudent,
                fourthStudent, fifthStudent, sixthStudent, seventhStudent,
                eighthStudent, ninthStudent, tenthStudent};

            ShowStudentsInfo(students);
            ShowSummerStudents(students);
            ShowCityStudents(students);

            Student[] pairOfStudents = firstStudent + secondStudent;

            //               ГОЛОВНІ ВИСНОВКИ
            // Структури в рази продуктивніші за класи, якщо не передаються як параметри та коли вони не мають багато параметрів.
            // Класи краще використовувати, коли зрозуміло, що робота буде із Reference типами, так як тоді передається лише посилання,
            //                                         а структурам доводиться копіюватись у нові структури, що збільшує час виконання.
        }
    }
}

