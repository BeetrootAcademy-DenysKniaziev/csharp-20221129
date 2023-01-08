//Finish describing ‘school’ domain. Define methods to add new pupils, organize classes, create schedule, update teacher’s information
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Xml.Linq;
using System.Reflection;
using System.ComponentModel.DataAnnotations;

namespace Homework11;

internal class Program
{
    public enum WDay
    {
        Monday,
        Tuesday,
        Wednsday,
        Thursday,
        Friday
    }
    public enum Timeslot
    {
        //[Display(Name = "8:00 - 8:45")]
        [Description("......................8:00 - 8:45     ")]
        First = 1,
        [Description("......................9:00 - 9:45     ")]
        Second = 2,
        [Description("......................10:00 - 10:45   ")]
        Third = 3,
        [Description("......................11:00 - 11:45   ")]
        Fourth = 4,
        [Description("......................12:00 - 12:45   ")]
        Fifth = 5,
        [Description("......................13:00 - 13:45   ")]
        Sixth = 6
    }
    static void Main(string[] args)
    {
        #region// 
        School School323 = new School();
        Pupil p1 = new Pupil("Dmytro","Bonislavskyi");
        Pupil p2 = new Pupil("Aleksandr","Katrusha");
        Pupil p3 = new Pupil("Oleksandr","Olenenko");
        Pupil p4 = new Pupil("Igor","Dainega");
        Pupil p5 = new Pupil("Yuliya", "Yakimchuk");
        Teacher t1 = new Teacher("Zoya Pavlovna", "Ordynskaya");
        Class cl1 = new Class();
        Class cl2 = new Class();

        cl1.Grade =  1;
        cl1.ClassName = "A";
        cl2.Grade = 1;
        cl2.ClassName = "B";
        cl1.PupilList.Add(p1);
        cl1.PupilList.Add(p2);
        cl1.PupilList.Add(p3);
        cl2.PupilList.Add(p4);
        cl2.PupilList.Add(p5);

        School323.TeacherList.Add(t1);
        School323.Classes.Add(cl1);
        School323.Classes.Add(cl2);
        #endregion

        while (true)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("School 323\n");
                Console.WriteLine("Select Action:");
                Console.WriteLine("1 - Show Classes");
                Console.WriteLine("2 - Create New Class");
                Console.WriteLine("3 - Update Teachers");
                //Console.WriteLine("4 - Create Teachers");
                Console.WriteLine("0 - Exit");

                var action = Console.ReadKey();
                Console.WriteLine();

                switch (action.Key)
                {
                    case ConsoleKey.D0:
                        Console.WriteLine("Exit");
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.D1:
                        Console.WriteLine("Show Classes:");
                        int cls = School323.ShowClasses();
                        if (cls != -1)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Class {School323.Classes[cls].Grade}  : {School323.Classes[cls].ClassName}");
                            Console.WriteLine("3 - Show/Create Schedule");
                            Console.WriteLine("Or Select Action for edit pupil:");
                            Console.WriteLine("1 - Delete Pupil");
                            Console.WriteLine("2 - Add Pupil");
                            Console.WriteLine("0 - Exit");

                            var act2 = Console.ReadKey();
                            Console.WriteLine();
                            switch (act2.Key)
                            {
                                case ConsoleKey.D0:
                                    Console.WriteLine("Exit");
                                    //Environment.Exit(0);
                                    break;

                                case ConsoleKey.D3:
                                    Console.WriteLine("Update Schedule");
                                    School323.Classes[cls].UpdateSchedule();
                                    //Environment.Exit(0);
                                    break;
                                case ConsoleKey.D1:
                                    Console.WriteLine("Delete Pupil");
                                    try
                                    {
                                        Console.WriteLine("input # of pupil from list above or input '-' to exit");
                                        var temppup = Console.ReadLine();
                                        if (temppup == "-")
                                        {
                                            Console.WriteLine("Exit");
                                            break;
                                        }
                                        School323.Classes[cls].PupilList.RemoveAt(Convert.ToInt32(temppup));
                                    }
                                    catch
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Wrong input of pupil Number");
                                    }
                                    break;
                                case ConsoleKey.D2:
                                    Console.WriteLine("Add Pupil");
                                    var pup = School323.Classes[cls].AddPupil();
                                    Console.WriteLine($"{pup.FirstName} {pup.LastName} was added to {School323.Classes[cls].Grade} : {School323.Classes[cls].ClassName} class");
                                    break;
                            }
                        }
                        //else
                        //}
                        //else { Console.WriteLine("No Classes added yet. You need to add one first"); }
                        break;
                    case ConsoleKey.D2:
                        Console.WriteLine("Create New Class:\n");
                        var NClass = School323.CreateNewClass();
                        if (NClass != null)
                        {
                            School323.Classes.Add(NClass);
                            Console.WriteLine($"{NClass.Grade}:{NClass.ClassName} class welcome to our school!");
                        }
                        break;
                    case ConsoleKey.D3:
                        Console.WriteLine("Update Teachers:");
                        if (School323.ShowTeachers())
                        {
                            Console.WriteLine("Input # of teacher above to update '-' to Exit or '+' to add new one");
                            var teacherN = Console.ReadLine();
                            try
                            {
                                if (teacherN == "-")
                                {
                                    Console.WriteLine("Exit");
                                    break;
                                }
                                if (teacherN == "+")
                                {
                                    School323.AddTeacher();
                                }
                                School323.UpdateTeacher(School323.TeacherList[Convert.ToInt32(teacherN)]);
                            }
                            catch
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong input of Teacher Number from List");
                            }
                        }
                        else { School323.AddTeacher(); }

                        break;

                    default:
                        Console.WriteLine("Incorrect Input!");
                        break;

                }
            }
            catch  { }
        }
    }


    class School {
        public List<Pupil> PupilList = new List<Pupil>();
        public List<Teacher> TeacherList = new List<Teacher>();
        public List<Class> Classes = new List<Class>();
        public Teacher AddTeacher()
        {
            Teacher tempT;
            try
            {
                Console.WriteLine("Input new Teachers First Name");
                var name = Console.ReadLine();
                Console.WriteLine("Input new Teachers Last Name");
                var lastname = Console.ReadLine();
                tempT = new Teacher(name, lastname);
                this.TeacherList.Add(tempT);
                return tempT;
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Wrong input of teacher Name");
                return tempT = null;
            }

        }
        public Schedule CreateSchedule() {
            var schedule = new Schedule();  
            return schedule;    
        }
        public Teacher UpdateTeacher(Teacher teacher) {
            Console.WriteLine($"Input Age for {teacher.FirstName} {teacher.LastName}:");
            try
            {
                var age = Console.ReadLine();
                teacher.Age = Convert.ToInt32(age);
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Wrong input for thecher Age"); 
            }
            return teacher;
        }

        internal int ShowClasses()        {
            int num = 0;

            if (Classes == null || Classes.Count == 0) { Console.WriteLine("No classes yet, first you need to add a class"); return -1; }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var cls in Classes)            {
                Console.WriteLine($"#{num}: Grade {cls.Grade}, Class Name {cls.ClassName} ");
                num++;
            }
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("\nSelect which class Organize/Reoganize (Pupils and Schedule)? By entering class # or '-' to exit");
            var selection = Console.ReadLine(); 
            try {  
                if (selection == "-") return -1;
                if(!Classes[Convert.ToInt32(selection)].ShowPupils()) return -1;
                //Classes[Convert.ToInt32(selection)].ShowTeachers();
                //Classes[Convert.ToInt32(selection)].ShowSchedule();
                return Convert.ToInt32(selection);
            }
            catch
            {
                Console.WriteLine("Wrong input");
                Console.Clear();
                return -1;
            }
        }

        internal Class CreateNewClass()
        {
            Class tempCl = new Class();
            try
            {
                Console.WriteLine("Please input class grade (1-11):");
                var input = Console.ReadLine();
                if (Convert.ToInt32(input) < 1 || Convert.ToInt32(input) > 11) throw new Exception( "input must be between 1 and 11");
                tempCl.Grade = Convert.ToInt32(input);   
                Console.WriteLine("Please input class name:");
                tempCl.ClassName = Console.ReadLine();
                return tempCl;
            }
            catch (Exception Ex)
            {
                Console.WriteLine("Wrong input\n" + Ex); 
                return tempCl = null;
            }
        }

        internal bool ShowTeachers() {

            int num = 0;
            if (TeacherList == null || TeacherList.Count == 0) {Console.WriteLine("No teachers yet, first you need to add a teacher"); return false; }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var teacher in TeacherList)    {
                Console.WriteLine($"# {num}: {teacher.FirstName} {teacher.LastName}");
                num++;
            }
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            return true;
        }
    }
    class Class {
        int _grade;
        string _classname;
        public int Grade { get { return _grade; } set { _grade = value; } }
        public string ClassName { get { return _classname; } set { _classname = value; } }
        public List<Pupil> PupilList = new List<Pupil>();
        public List<Teacher> TeacherList= new List<Teacher>();
        public Schedule _schedule = new Schedule();

        internal void ShowTeachers()   {
            int num = 0;
            Console.WriteLine($"Teachers of the Class {_grade} {_classname}");
            foreach (var teacher in TeacherList)            {
                Console.WriteLine($"# {num}: {teacher.FullName}");
                num++;
            }
            Console.WriteLine("\n");
        }
        internal bool ShowPupils()
        {
            int num = 0;
            Console.WriteLine($"Pupil of the Class {_grade} {_classname}");
            if (PupilList == null || PupilList.Count == 0) { 
                Console.WriteLine("No pupils in this class to Organize/Reorganize, lets add one first");
                var pup = this.AddPupil();
                if (pup != null)
                       Console.WriteLine($"{pup.FirstName} {pup.LastName} was added to {Grade}:{ClassName} class");
                else Console.WriteLine("new pupil was not created");
                //return true; 
            }// this.AddPupil() }
            Console.ForegroundColor = ConsoleColor.Green;
            foreach (var pupil in PupilList)
            {
                Console.WriteLine($"# {num}: {pupil.FirstName} {pupil.LastName}");
                num++;
            }
            Console.ForegroundColor = ConsoleColor.White;
            //Console.WriteLine("\n");
            return true;
        }
        internal void ShowSchedule()
        {
            Console.WriteLine($"Schedule of the Class {_grade} {_classname}");
            foreach (var slot in _schedule.SlotList)
            {
                Console.WriteLine($" {slot._timeslot}  :  {slot._day}  :  {slot.Subject}");
            }
            Console.WriteLine("\n");
        }
        public Pupil AddPupil()
        {
            //Console.WriteLine("Add Pupil");
            Pupil temppup;
            try
            {
                Console.WriteLine("Input new pupil First Name");
                var name = Console.ReadLine();
                Console.WriteLine("Input new pupil Last Name");
                var lastname = Console.ReadLine();
                temppup = new Pupil(name, lastname);
                this.PupilList.Add(temppup);
                return temppup;
            }
            catch
            {
                Console.Clear();
                Console.WriteLine("Wrong input of pupil Name");
                return temppup = null;
            }
        }
        public Pupil DeletePupil(String name, String lastName)
        {
            var pup = new Pupil(name, lastName);
            return pup;
        }

        internal void UpdateSchedule()
        {
            if (_schedule.SlotList == null || _schedule.SlotList.Count == 0)
            {
                foreach (var d in Enum.GetNames(typeof(WDay)))
                {
                    foreach (var ts in Enum.GetValues(typeof(Timeslot)))
                    {
                        var tempSlot = new Slot("Empty");

                        _schedule.SlotList.Add(tempSlot);
                    }
                }
            }


            int slt = 0;
            foreach (var d in Enum.GetNames(typeof(WDay)))
            {
                Console.WriteLine($"{d}");
                Console.WriteLine("------------");
                foreach (var ts in Enum.GetValues(typeof(Timeslot)))
                {
                    var description = GetDescription((Timeslot)ts);
                    Console.WriteLine($"{ts} {description} {this._schedule.SlotList[slt].Subject}");
                    slt++;
                }
                Console.WriteLine("\n");
            }


            slt = 0;
            foreach (var d in Enum.GetNames(typeof(WDay)))
            {
                foreach (var ts in Enum.GetValues(typeof(Timeslot)))
                {
                    var description = GetDescription((Timeslot)ts);
                    Console.WriteLine($"Input new Subject for {d}  {description} now it is {this._schedule.SlotList[slt].Subject} ");
                    var sbj = Console.ReadLine();
                    if (sbj != "" && sbj != null) this._schedule.SlotList[slt].Subject = sbj;
                    slt++;
                }
            }

        }

        public static string GetDescription(Enum ts)
        {
            var enumMember = ts.GetType().GetMember(ts.ToString()).FirstOrDefault();
            var descriptionAttribute =
                enumMember == null
                    ? default(DescriptionAttribute)
                    : enumMember.GetCustomAttribute(typeof(DescriptionAttribute)) as DescriptionAttribute;
            return
                descriptionAttribute == null
                    ? ts.ToString()
                    : descriptionAttribute.Description;
        }
    }


    class Pupil : Person {
        Class _class;
        public Pupil(string firstName, string lastName) : base(firstName, lastName) { 
            FirstName = firstName; LastName = lastName; 
        }
    }
    class Teacher : Person  {
        public Teacher(string firstName, string lastName) : base(firstName, lastName)  {   }
    }

    class Schedule { 
        public List<Slot> SlotList = new List<Slot>();
    }
    public class Slot
    {
        public string Subject { get; set; }
        public WDay _day;
        public Timeslot _timeslot;
        public Slot(string subject)//, WDay day,Timeslot timeslot)
        {
            Subject = subject;
            //_day = day;
            //_timeslot = timeslot;
        }
    }


    class Person {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
        public string FullName() { return this.FirstName.ToString() + " " + this.LastName.ToString(); }


    }


}