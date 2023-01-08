using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    public class Class
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }
        public Schedule Schedule { get; set; }
        public Teacher Teacher { get; set; }

        public Class()
        {
            Students = Array.Empty<Student>();
        }

        public Class(string name) 
        {
            this.Name = name;   
            Students = Array.Empty<Student>();   
        }

        public Class(string name, Student[] students)
        {
            this.Name = name;
            this.Students = students;
        }

        public Class(string name, Student[] students, Schedule schedule)
        {
            this.Name = name;
            this.Students = students;
            this.Schedule = schedule;   
        }

        public void AddNewStudent() 
        {
            Student student = new Student();
            student.AddStudent();
            var newStudents = new Student[Students.Length + 1];
            Array.Copy(Students, newStudents, Students.Length);
            Students = newStudents;
            Students[^1] = (student); ;
        }

        public override string ToString()
        {
            Console.WriteLine("Class name: " + Name + ", Teacher: " + Teacher);
            foreach (var student in Students)
            {
                Console.WriteLine( "Class name: " + Name + ", Student: " + student);
            }
            return "\n";
        }
    }

}
