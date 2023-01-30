using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson11.Homework
{
    internal class OperationsWithPeople
    {
        public static void AddPupilToClass(Pupil pupil, List<Pupil> classs)
        {
            classs.Add(pupil);
        }
        public static void RemovePupilFromClass(Pupil pupil, List<Pupil> classs)
        {
            classs.Remove(pupil);
        }
    }
}
