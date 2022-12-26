using System.Text;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {

        var pup = new Pupil()
        {
            Name = "Vladislav",
            LastName = "Noname",
            PhoneNumber = 999222331,
            DateOfBorn = DateTime.Now.AddYears(-6)
        };

        Console.WriteLine(pup);
    }
}
class Pupil
{
    string _name;
    string _lastName;
    long _phoneNumber;
    DateTime _dateOfBirth;
    public string Name
    {
        get => _name;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _name = value;
            else
                throw new ArgumentException("Invalid Name");
        }

    }
    public string LastName
    {
        get => _lastName;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _lastName = value;
            else
                throw new ArgumentException("Invalid LastName");
        }
    }

    public long PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]{9}$"))
                _phoneNumber = value;
            else
                throw new ArgumentException("Invalid PhoneNumber");
        }
    }

    public DateTime DateOfBorn
    {
        get => _dateOfBirth;

        set
        {
            if (DateOfBorn > DateTime.Now.AddYears(-4))
                throw new ArgumentException("The child is too small");
            else
                _dateOfBirth = value;
        }
    }

    public override string ToString()
    {
        return $"Name: {Name,8}, Last Name: {LastName,8}, Phone number: {PhoneNumber:+(###)###-##-##}, Date of born: {DateOfBorn}";
    }

}
class Teacher
{
    string _name;
    string _lastName;
    long _phoneNumber;

    public string Name
    {
        get => _name;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _name = value;
            else
                throw new ArgumentException("Invalid Name");
        }

    }
    public string LastName
    {
        get => _lastName;
        set
        {
            if (Regex.IsMatch(value, @"^[A-Z]{1}[a-z]+$"))
                _lastName = value;
            else
                throw new ArgumentException("Invalid LastName");
        }

    }
    public long PhoneNumber
    {
        get => _phoneNumber;
        set
        {
            if (Regex.IsMatch(value.ToString(), @"^[0-9]{9}$"))
                _phoneNumber = value;
            else
                throw new ArgumentException("Invalid PhoneNumber");
        }
    }

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
    string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (Regex.IsMatch(value, @"^\w*$"))
                _name = value;
            else
                throw new ArgumentException("Invalid Name");
        }

    }

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
    string _name;
    public string Name
    {
        get => _name;
        set
        {
            if (Regex.IsMatch(value, @"^\w*$"))
                _name = value;
            else
                throw new ArgumentException("Invalid Name");
        }

    }

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
        byte _hour;
        byte _minute;
        int _classRoom;
        Teacher _teacher;
        Subject _subject;
        Class _myClass;
        DayOfWeek Day { get; set; }
        byte Hour
        {
            get => _hour;
            set
            {
                if (value > 24 || value < 0)
                    throw new ArgumentOutOfRangeException("Invalid Hour");
                _hour = value;
            }
        }
        byte Minute
        {
            get => _minute;
            set
            {
                if (value > 60 || value < 0)
                    throw new ArgumentOutOfRangeException("Invalid Minute");
                _minute = value;
            }
        }
        int Classroom { get; set; }
        Teacher Teacher
        {
            get => _teacher;
            set
            {
                if (!value.Subjects.Contains(Subject))
                    throw new ArgumentException("This teacher does not teach the given subject.");
                else
                    _teacher = value;
            }
        }
        Subject Subject
        {
            get => _subject;
            set
            {
                if(value is null)
                    throw new ArgumentNullException("Subject can't be null");
                _subject = value;
            }
        }
        Class MyClass
        {
            get => _myClass;
            set
            {
                if (value is null)
                    throw new ArgumentNullException("MyClass can't be null");
                _myClass = value;
            }
        }

        public Lesson(DayOfWeek day, byte hour, byte minute, int classroom, Teacher teacher, Subject subject, Class myClass)
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