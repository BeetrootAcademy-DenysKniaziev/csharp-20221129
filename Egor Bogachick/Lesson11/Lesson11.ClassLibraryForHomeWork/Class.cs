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

        public void AddStudent(Student[] Students) 
        {
            Array.Resize(ref Students, Students.Length + 1);
            Students[^1] = (student);
        }
    }

}
