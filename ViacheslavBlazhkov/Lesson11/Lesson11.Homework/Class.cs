using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class Class
    {
		private string _title;
		private Pupil[] _pupils;

		public string Title
		{
			get { return _title; }
			set { _title = value; }
		}
        public Pupil[] Pupils
        {
            get { return _pupils; }
            set { _pupils = value; }
        }

        public Class(string title) 
		{ 
			_title = title; 
			_pupils= new Pupil[1];
		}
		public Class(string title, Pupil[] pupils)
		{
			_title = title;
			_pupils = pupils;
		}
	}
}
