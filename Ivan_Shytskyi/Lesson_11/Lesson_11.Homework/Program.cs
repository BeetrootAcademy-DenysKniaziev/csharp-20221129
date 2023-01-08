class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public int Age { get; set; }
    public Person(string first, string last, int age)
    {
        FirstName = first;
        LastName = last;
        Age = age;
    }

}
class Teacher
{
    public Person personTeacher { get; set; }
    public string Profession { get; set; }

    public Teacher(string first, string last, int age, string profession)
    {
        personTeacher = new Person(first, last, age);
        Profession = profession;
    }
    private string ConvertToString()
    {
        return $"{personTeacher.FullName}, Age - {personTeacher.Age}, Profession - {Profession}";
    }
    public override string ToString()
    {
        return ConvertToString();
    }
}
class Student
{
    public Person personStudent;
    public Student(string first, string last, int age)
    {
        personStudent = new Person(first, last, age);
    }
    private string ConvertToString()
    {
        return $"{personStudent.FullName}, Age - {personStudent.Age}";
    }
    public override string ToString()
    {
        return ConvertToString();
    }
}
class Class
{
    public string NameClass { get; set; }
    public Teacher T { get; set; }
    Student[] S;
    public int Length;
    public Class(string nameClass, Teacher t, Student s)
    {
        NameClass = nameClass;
        T = t;
        S = new Student[1];
        S[0] = s;
    }
    public void AddNewStudent(Student newStudent)
    {
        var newS = new Student[S.Length + 1];
        Array.Copy(S, newS, S.Length);
        newS[newS.Length - 1] = newStudent;
        S = newS;
    }
    public void WriteAllStudents()
    {
        foreach (var student in S)
        {
            Console.WriteLine(student);
        }
    }
    private string ConvertToString()
    {
        return $"Class - {NameClass} \n{T.personTeacher.FullName} \nnumber of students - {S.Length}";
    }
    public override string ToString()
    {
        return ConvertToString();
    }
}

class Schedule
{
    public Teacher T { get; set; }
    public Class C { get; set; }
    public string Day { get; set; }
    public TimeOnly Hour { get; set; }
    public int ClassRoom { get; set; }
    public Schedule(Teacher teacher, Class class0, string day, int hour, int classRoom)
    {
        TimeOnly t = new TimeOnly();
        Hour = t.AddHours(hour);
        T = teacher;
        C = class0;
        Day = day;
        ClassRoom = classRoom;
    }
    public void ScheduleWrite()
    {
        Console.WriteLine($"Teacher - {T.personTeacher.FullName}\nClass - {C.NameClass}\nDay and hour - {Day} ({Hour})\nClassroom - {ClassRoom}");
    }
}
class OrganizeClasses
{
    string[] subArr = new string[] { "math", "physics", "chemistry", "chemistry", "history", "biology" };
    public Class C { get; set; }
    public OrganizeClasses(Class class1)
    {
        C = class1;
    }
    public void Organaize(string day)
    {
        Random rd = new Random();
        switch (day)
        {
            case "Monday":
                Console.WriteLine($"Monday class {C}:\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}");
                break;
            case "Tuesday":
                Console.WriteLine($"Tuesday class {C}:\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}");
                break;
            case "Wednesday":
                Console.WriteLine($"Wednesday class {C}:\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}");
                break;
            case "Thursday":
                Console.WriteLine($"Thursday class {C}:\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}");
                break;
            case "Friday":
                Console.WriteLine($"Friday class {C}:\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}\n{subArr[rd.Next(0, 5)]}");
                break;
        }
    }
}
class Program
{
    public static void Main()
    {
        Teacher t1 = new Teacher("Diana", "Sokol", 30, "teacher of physics");
        Student s1 = new Student("Max", "Keks", 16);
        Student s2 = new Student("Vax", "Meks", 16);
        Student s3 = new Student("Nak", "Beks", 15);
        Student s4 = new Student("Mak", "Reks", 15);
        Student s5 = new Student("Vin", "Rekes", 15);
        Class class1 = new Class("10-A", t1, s1);
        Schedule scheduleForTeacher = new Schedule(t1, class1, "Monday", 9, 115);
        OrganizeClasses org = new OrganizeClasses(class1);
        Console.WriteLine(class1);  // == Console.WriteLine($"class - {class1.NameClass} teacher - {class1.T.personTeacher.FullName}");
        class1.AddNewStudent(s2);
        Console.WriteLine(class1);
        class1.WriteAllStudents();
        scheduleForTeacher.ScheduleWrite();
        org.Organaize("Monday");
    }
}
