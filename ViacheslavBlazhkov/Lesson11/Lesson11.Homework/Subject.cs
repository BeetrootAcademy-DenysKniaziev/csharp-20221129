using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class Subject
    {
		private string _title;

        public string Title
		{
			get { return _title; }
			set { _title = value; }
		}

		public Subject(string title)
		{
			_title = title;
		}
	}
}
