using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class Pupil : Person
    {
		private List<Pupil> _class;

		public List<Pupil> Class
		{
			get { return _class; }
			set { _class = value; } 
		}

        public Pupil(string firstName, string lastName) : base(firstName, lastName) { }
		public Pupil(string firstName, string lastName, List<Pupil> classs) : base(firstName, lastName)
		{
			OperationsWithPeople.AddPupilToClass(this, classs);
			_class = classs;
		}

		public override string ToString()
		{
			return $"{FirstName} {LastName}";

		}
    }
}
