using System.Text.RegularExpressions;

class Class
{

    public string Name { get; set; }
    public Student[] Students { get; set; }
    public Class(string name, Student[] students)
    {
        Name = name;
        Students = students;
    }
    public void AddPupil(Student pupil)
    {
        var newPupils = new Student[Students.Length + 1];
        Array.Copy(Students, newPupils, Students.Length);
        Students = newPupils;
        Students[Students.Length - 1] = pupil;
    }
}

class Teacher
{
    public string Name { get; set; }
    public string Subject { get; set; }
}

class Student
{
    string _name;
    string _lastname;

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _name = value;
            else Console.WriteLine("Invalid First Name");
        }
    }
    public string Lastname
    {
        get => _lastname;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _lastname = value;
            else Console.WriteLine("Invalid Last Name");
        }
    }

    public Class Class { get; set; }

    public Student(string name, string lastname, Class _class)
    {
        Name = name;
        Lastname = lastname;
        Class = _class;
    }

    public Teacher Teacher { get; set; }

}
class Program
{
    static void Main()
    {
        var arrStud = new Student[100];

        var classA = new Class("A1", arrStud[0..2]);
        var classB = new Class("B1", arrStud[2..4]);
        var classC = new Class("C1", arrStud[4..6]);

        arrStud[0] = new Student("Artem", "Sushko", classA);
        arrStud[1] = new Student("Tom", "Tomas", classA);
        arrStud[2] = new Student("Ben", "Ten", classB);
        arrStud[3] = new Student("Bill", "Li", classB);
        arrStud[4] = new Student("John", "Smith", classC);
        arrStud[5] = new Student("Max", "Mini", classC);

        classA.AddPupil(arrStud[0]);
        classA.AddPupil(arrStud[1]);
        classB.AddPupil(arrStud[2]);
        classA.AddPupil(arrStud[3]);
        classA.AddPupil(arrStud[4]);
        classA.AddPupil(arrStud[5]);

        Teacher teacher1 = new Teacher
        {
            Name = "Alisa",
            Subject = "Math"
        };

    }
}