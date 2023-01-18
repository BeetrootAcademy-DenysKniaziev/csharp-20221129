namespace Lesson11.Homework;
class Program
{
    static void Main(string[] args)
    {
        Class c1 = new Class("1-A");
        Pupil p1 = new Pupil("Oleksiy", "Ivankov");
        Pupil p2 = new Pupil("Galkovich", "Nazar");
        var list = new List<Pupil> { p1, p2 };
        Console.WriteLine("Class " + c1.Title);
        OperationsWithPeople.RemovePupilFromClass(p2, list);
        foreach (var item in list)
        {
            Console.WriteLine(item);
        }
        Console.WriteLine();

        Subject geography = new Subject("Geography");
        Subject math = new Subject("Mathematics");
        Subject english = new Subject("English");
        Subject physEduc = new Subject("Physical Education");

        DayOfWeek monday = new DayOfWeek("Monday", new[] { geography, math, english });
        DayOfWeek tuesday = new DayOfWeek("Tuesday", new[] { physEduc, math, geography });

        Schedule schedule1 = new Schedule(new[] { monday, tuesday });

        schedule1.ShowSchedule();

        Teacher teach1 = new Teacher("Olha", "Glazacheva", english);
    }
}