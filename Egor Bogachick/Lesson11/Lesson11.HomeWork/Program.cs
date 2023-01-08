using Lesson11.ClassLibraryForHomeWork;

class Program
{
    static void Main()
    {
        Teacher teacher1 = new("Max", "Li", 45);
        Student student1 = new("Egor", "Bogachik", 19);

        var students = new Student[1];
        students[0] = student1; 
        Class class1 = new( "A1", students);
        class1.Teacher = teacher1;
        class1.AddNewStudent();
        class1.AddNewStudent();
        Console.WriteLine(class1.ToString());

        Subject subject1= new Subject("Math", "12:30"); 
        var subjects = new Subject[1];
        subjects[0] = subject1; 
        Schedule schedule1 = new("Monday", subjects);
        class1.Schedule = schedule1;
        schedule1.AddNewSubject();
        Console.WriteLine(schedule1.ToString());
    } 
}

