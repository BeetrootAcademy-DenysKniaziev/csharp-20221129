using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class Schedule
    {
		private DayOfWeek[] _dayOfWeek;

		public DayOfWeek[] DayOfWeek
		{
			get { return _dayOfWeek; }
			set { _dayOfWeek = value; }
		}

		public Schedule(DayOfWeek[] dayOfWeek)
		{
			_dayOfWeek = dayOfWeek;
		}

        public void ShowSchedule()
        {
            foreach(DayOfWeek dayOfWeek in _dayOfWeek)
			{
				Console.WriteLine(dayOfWeek.Title);
				foreach (var item in dayOfWeek.Subjects)
				{
					Console.WriteLine(item.Title);
				}
				Console.WriteLine();
			}
        }
    }
}
