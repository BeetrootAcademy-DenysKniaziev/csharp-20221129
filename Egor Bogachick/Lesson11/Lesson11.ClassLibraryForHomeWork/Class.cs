using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.ClassLibraryForHomeWork
{
    internal class Class
    {
        public string Name { get; set; }
        public Student[] Students { get; set; }

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

        public void AddNewStudent(ref Student[] Students) 
        {
            Student student = new Student();
            student.AddStudent();
            Array.Resize(ref Students, Students.Length + 1);
            Students[^1] = (student);
        }
    }

}
