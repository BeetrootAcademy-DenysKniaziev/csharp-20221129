using System.Text;

class Program
{
    static void Main()
    {
        var pup = new Pupil()
        {
            Name = "Vladislav",
            LastName = "Noname",
            PhoneNumber = 9992223311,
            DateOfBorn = DateTime.Now
        };

        Console.WriteLine(pup);
    }
}
class Pupil
{
    public string Name { get; set; }
    public string LastName { get; set; }

    public long PhoneNumber { get; set; }

    public DateTime DateOfBorn { get; set; }

    public override string ToString()
    {
        return $"Name: {Name,8}, Last Name: {LastName,8}, Phone number: {PhoneNumber:+(###)###-##-##}, Date of born: {DateOfBorn}";
    }

}
class Teacher
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public long PhoneNumber { get; set; }

    public Subject[] Subjects { get; }

    public int CountOfSubjects
    {
        get
        {
            var count = 0;
            foreach (var subject in Subjects)
            {
                if (subject != null)
                    count++;
            }
            return count;
        }
    }


    public Teacher(string name, string lastName, long phoneNumber)
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Subjects = new Subject[3];
    }
    public void AddSubject(Subject newSubject)
    {
        if (Subjects.Contains(null) || Subjects.Contains(newSubject))
            Subjects[Array.IndexOf(Subjects, null)] = newSubject;
        else
            Console.WriteLine("This teacher already has a maximum number of subjects or this subject has been added before.");

    }
    public void RemoveSubject(Subject oldSubject)
    {
        if (Subjects.Contains(oldSubject))
        {
            Subjects[Array.IndexOf(Subjects, oldSubject)] = null;
        }
        else
        {
            Console.WriteLine("Teacher has not this subject.");
        }
    }
    public override string ToString()
    {
        return $"Name: {Name,8}, Last Name: {LastName,8}, Phone number: {PhoneNumber:+(###)###-##-##}";
    }
}

class Class
{
    public string Name { get; set; }

    public int CountOfPupils
    {
        get
        {
            return Pupils.Count();
        }
    }
    public Pupil[] Pupils { get; private set; }
    public Class(string name)
    {
        Name = name;
        Pupils = new Pupil[0];
    }
    public void AddPupil(Pupil pupil)
    {
        var newPupils = new Pupil[Pupils.Length + 1];
        Array.Copy(Pupils, newPupils, Pupils.Length);
        Pupils = newPupils;
        Pupils[Pupils.Length - 1] = pupil;

    }
    /// <summary>
    /// Return true if Remove was completed
    /// </summary>
    public bool RemovePupil(Pupil pupil)
    {
        if (Pupils.Contains(pupil))
        {
            int id = Array.IndexOf(Pupils, pupil);
            var newPupils = new Pupil[Pupils.Length - 1];
            Array.Copy(Pupils, 0, newPupils, 0, id);
            Array.Copy(Pupils, id + 1, newPupils, id, Pupils.Length - id - 1);

            Pupils = newPupils;
            return true;
        }
        return false;
    }

}


class Subject
{
    public string Name { get; set; }

    public StringBuilder Plan { get; }

    public Subject(string name)
    {
        Name = name;
        Plan = new StringBuilder();
    }
    public void AddedInPlan(string text)
    {
        Plan.Append(text);
    }
    public override string ToString()
    {
        return Name;
    }

}

static class Schedule
{
    public static Lesson[] Records { get; private set; }
    static Schedule()
    {
        Records = new Lesson[0];
    }
    public static void Add(Lesson lesson)
    {

        var newRecords = new Lesson[Records.Length + 1];
        Array.Copy(Records, newRecords, Records.Length);
        Records = newRecords;
        Records[Records.Length - 1] = lesson;

    }
    public static bool Remove(Lesson lesson)
    {
        if (Records.Contains(lesson))
        {
            int id = Array.IndexOf(Records, lesson);
            var newRecords = new Lesson[Records.Length - 1];
            Array.Copy(Records, 0, newRecords, 0, id);
            Array.Copy(Records, id + 1, newRecords, id, Records.Length - id - 1);

            Records = newRecords;
            return true;
        }
        return false;
    }

    static void ClearSchedule()
    {
        Records = null;
    }
    public class Lesson
    {
        DayOfWeek Day { get; set; }
        int Hour { get; set; }
        int Minute { get; set; }
        int Classroom { get; set; }
        Teacher Teacher
        {
            get => Teacher;
            set
            {
                if (!value.Subjects.Contains(Subject))
                    throw new ArgumentException("This teacher does not teach the given subject.");
                else
                    Teacher = value;
            }
        }
        Subject Subject { get; set; }
        Class MyClass { get; set; }

        public Lesson(DayOfWeek day, int hour, int minute, int classroom, Teacher teacher, Subject subject, Class myClass)
        {
            Day = day;
            Hour = hour;
            Minute = minute;
            Classroom = classroom;
            Subject = subject;
            Teacher = teacher;
            MyClass = myClass;

        }
    }
}
