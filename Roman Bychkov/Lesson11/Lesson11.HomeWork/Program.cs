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

    public Teacher(string name, string lastName, long phoneNumber)
    {
        Name = name;
        LastName = lastName;
        PhoneNumber = phoneNumber;
        Subjects = new Subject[5];
    }
    public void AddSubject(Subject newSubject)
    {
        if (Subjects.Contains(null))
            Subjects[Array.IndexOf(Subjects, null)] = newSubject;
        else
            Console.WriteLine("The teacher has a complete list of subjects.");

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

    public int CountOfPupil { get; set; }
    public Pupil[] Pupils { get; private set; }
    public Class(string name)
    {
        Name = name;
        //Pupils = new Pupil[CountOfPupil];
    }
    public void AddPupil(Pupil pupil)
    {
        if (Pupils == null)
        {
            Pupils = new Pupil[1];
            Pupils[0] = pupil;
        }
        else
        {
            var newPupils = new Pupil[Pupils.Length + 1];
            Array.Copy(Pupils, newPupils, Pupils.Length);
            Pupils = newPupils;
            Pupils[Pupils.Length - 1] = pupil;
        }
    }
    /// <summary>
    /// Return true if Remove was completed
    /// </summary>
    public bool RemovePupil(ref Pupil pupil)
    {
        if(Pupils.Contains(pupil))
        {
            int id = Array.IndexOf(Pupils,pupil);
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

}

class Schedule
{

}