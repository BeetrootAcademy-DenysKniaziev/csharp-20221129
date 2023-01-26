
using System.Linq;
using System.Threading.Channels;

class Class
{

    public string ClassNumber { get; set; }
    public Student[] Students { get; set; }
    public Teacher[] Teachers { get; set; }
    public Class(string number, Student[] students)
    {
        ClassNumber = number;
        Students = (Student[])students.Clone();

    }
    public Class(string number)
    {
        ClassNumber = number;
        Students = Array.Empty<Student>();
        Teachers = Array.Empty<Teacher>();
    }

    public void AddStud(Student student)
    {
        var newStudents = new Student[Students.Length + 1];
        Array.Copy(Students, newStudents, Students.Length);
        Students = newStudents;
        Students[Students.Length - 1] = student;

    }
    public void AddTeach(Teacher teacher)
    {
        var newTeachers = new Teacher[Teachers.Length + 1];
        Array.Copy(Teachers, newTeachers, Teachers.Length);
        Teachers = newTeachers;
        Teachers[Teachers.Length - 1] = teacher;

    }

    public override string ToString()
    {

        var result = $"Class number:{ClassNumber}\n";

        foreach (var teacher in Teachers)
        {
            result += teacher.ToString();
        }
        foreach (var student in Students)
        {

            result += student.ToString();
        }
        return result;
    }

}
class Teacher
{
    private string _name;
    public string Name
    {
        get => _name;
        set => _name = value;
    }
    public string Surname { get; set; }
    public Class Class { get; set; }
    public Teacher(string name, string lastName, Class studentClass)
    {
        Name = name;
        Surname = lastName;
        Class = studentClass;
    }


    public override string ToString()
    {
        return $"Teacher" +
            $"Surname: {Surname} Name: {Name}\n";
    }
}
class Student
{
    private string _name;
    public string Name    
    {
        get => _name;
        set => _name = value;
    }
    public string LastName { get; set; }
    public Class Class { get; set; }
    public Teacher Teacher { get; set; }
   
    public Student(string name, string lastName, Class studentClass)
    {
        Name = name;
        LastName = lastName;
        Class = studentClass;

    }



    public override string ToString()
    {


        return
            $"Name: {Name}; Last name: {LastName};\n";
    }


}



class Program
{
    static void Main()
    {

        var class101 = new Class("A1");
        //var arrStud = new Student[50];

        class101.AddTeach(new Teacher("Taras", "Grigorovich", class101));
        class101.AddStud(new Student("Marian", "Zhyganov", class101));
        class101.AddStud(new Student("Oleg", "Mura", class101));
        class101.AddStud(new Student("Nazar", "Brunar", class101));
        class101.AddStud(new Student("Sanya", "Yagelo", class101));
        class101.AddStud(new Student("Nastya", "Volosh", class101));

        //arrStud[0] = new Student("Marian", "Zhyganov", class101);
        //arrStud[1] = new Student("Oleg", "Mura", class101);
        //arrStud[2] = new Student("Nazar", "Brunar", class101);
        //arrStud[3] = new Student("Sanya", "Yagelo", class101);
        //arrStud[4] = new Student("Nastya", "Volosh", class101);

        //class101.AddStud(arrStud[0]);
        //class101.AddStud(arrStud[1]);
        //class101.AddStud(arrStud[2]);
        //class101.AddStud(arrStud[3]);
        //class101.AddStud(arrStud[4]);




        Console.WriteLine(class101);


    }
}
