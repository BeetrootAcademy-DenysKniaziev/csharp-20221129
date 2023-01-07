using System.Linq;

namespace School
{
    class Student
    {
        Student[] listOfStudents = new Student[50];
        private string name;
        public int age;

        public Student(string name, int age)
        {
this.name = name;
            this.age = age;
        }

        public int Age { get; set; }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }



        static public void AddNewStudents()
        {
            Console.WriteLine("Insert name");
            new Student.name = Console.ReadLine();
            Console.WriteLine("Insert age");
            Student.Age = Convert.ToInt32(Console.ReadLine());
            Student student1 = new Student(name, age);
            Array.Resize(ref listOfStudents, listOfStudents.Length + 1);
            listOfStudents[listOfStudents.Length - 1] = student1;


        }
        static void Main()
        {
            AddNewStudents();

        }
    }
}