

public class Student
{
    public string Name; 
    public int Classes;
    public Teacher Teacher;

    public Student(string name, int classes, Teacher teacher)
    {
        Name = name;
        Classes = classes;
        Teacher = teacher;
        Teacher.Students.Add(this);
    }
}

public class Teacher
{
    public string Name;
    public string LastName;
    public int NumberOfClasses;
    public int DayHours;
    public int WeekHours;
    public IList<Student> Students = new List<Student>();
    public Schedule Schedule;
    

    public Teacher(string name, string lastName)
    {
        Name = name;
        LastName = lastName;
    }
    
    public void CountNumberOfClasses()
    {
        int sum = 0;
        foreach (Student s in Students)
        {
            sum += s.Classes;
        }
        NumberOfClasses = sum;
    }

    public void CreateWeekSchedule()
    {
        int Hours = 0;

        foreach(var item in Schedule.Subjects)
        {
            Hours += item.Value;
        }
        WeekHours = NumberOfClasses * Hours;

        DayHours = WeekHours / Schedule.Days;
    }
}

public class Schedule
{
    public string GroupName;
    public Dictionary<string, int> Subjects = new Dictionary<string, int>();
    public int ClassesInWeek;
    public int Days;

    public Schedule (string groupName, int days)
    {
        GroupName = groupName;
        Days = days;
    }

    public void AddSubject(string subjectName, int hours)
    {
        Subjects.Add(subjectName, hours);
    }

    public void DelSubject(string subjectName)
    {
        Subjects.Remove(subjectName);
    }

    public void ChangeSubjectHours(string subjectName, int hoursNew)
    {
        Subjects.Remove(subjectName);
        Subjects.Add(subjectName, hoursNew);
    }

}

public class Program
{
    public static void Main(string[] args)
    {
        Teacher AnnaSagan = new Teacher("Анна", "Саган");

        Student Jumaliash = new Student("Йулія", 2, AnnaSagan);
        Student AditVeber = new Student("Вєта", 3, AnnaSagan);
        Student Dakhoven = new Student("Рена", 2, AnnaSagan);
        Student Irynafed7 = new Student("Ірина", 3, AnnaSagan);
        Student Sedjex = new Student("Катерина", 2, AnnaSagan);

        Schedule W1 = new Schedule("GR-1", 6);
        AnnaSagan.Schedule = W1;

        W1.AddSubject("English speaking", 1);
        W1.AddSubject("English writing", 1);

        AnnaSagan.CountNumberOfClasses();
        AnnaSagan.CreateWeekSchedule();

        Console.WriteLine($"Number of classes for {AnnaSagan.Name} is {AnnaSagan.NumberOfClasses.ToString()} for group {W1.GroupName}.");
        Console.WriteLine($"Hours per week: {AnnaSagan.WeekHours}.");
        Console.WriteLine($"Working days: {AnnaSagan.Schedule.Days}.");
        Console.WriteLine($"Daily teacher hours per week:{AnnaSagan.DayHours}.");
    }
}