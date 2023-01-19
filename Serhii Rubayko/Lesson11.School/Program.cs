class SchoolDomain
{


    class School
    {
        public int NumderOfClasses { get; set; }

        public int Grade { get; set; }

        //enum Subjects { Chemistry = 0, Physics = 1, Biology = 2, Algebra = 3, Language = 4 };
    }
        class Schedule
        {

            //public int Grade 
            public List<string> Subjects { get; set; }
            public List<string> Days { get; set; }

            public string [,] Routine {get;set; }

              //public 
                              
                //= List<string> { "Chemistry", "Physics", "Biology", "Algebra", "Language" };

                public  Schedule(int numberOfLess)
                {
                    Subjects= new List<string> { "Chemistry", "Physics", "Biology", "Algebra", "Language" };
                    Days= new List<string> { "Monday", "Tuesday", "Wensday", "Thaturday", "Friday" };
                    
                    for ( int i = 0; i < numberOfLess;i++ )
                    {
                        for (int j=0; j<5; j++)
                        {
                            if (i + j < 5)
                            {
                            Routine[i, j] = Subjects[j + i];
                            }
                            else
                            { 
                            Routine[i, j] = Subjects[j + i - 5];
                            }

                        }
                    }

                }

            public void PrintSchedule()
            {
                for (int i=0; i<Routine.GetLength(0); i++)
                {
                    Console.Write(Routine[0, i]);
                }


            }

             //class Day
            //{
            //    public List<string> WeakDays 
            //     {
            //        get 
            //        { return new List<string> 
            //            { "Monday", "Tuesday", "Wensday", "Tuesday", "Friday", "Saturday", "Suday"};
            //        }
            //}


            //public List<Day> days { get; set; }

            //public Schedule(int Grade)
            //{
            //    Grade5=new 

            //}
        }

    

    

    class Person
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int YearOfBirth { get; set; }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }

        public int Age
        {
            get { return DateTime.Now.Year - YearOfBirth; }
        }

        public Person(string firstName, string lastName, int yearOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
        }

        public Person()
        {

        }

        public override string ToString()
        {
            if (YearOfBirth != 0)
                return $"Person:{this.FullName}\nYears of birth:{this.YearOfBirth}";

            return $"Person:{this.FullName}";
        }

    }

    class Pupil : Person
    {
        public int GradeOfScholl
        {
            get
            {
                switch (Age)
                {
                    case 11:
                        return 5;
                    case 12:
                        return 6;
                    case 13:
                        return 7;
                    case 14:
                        return 8;
                    case 15:
                        return 9;
                    default:
                        return 0;
                }

            }
        }

        public Pupil(string firstName, string lastName, int yearOfBirth) : base(firstName, lastName, yearOfBirth)
        {
        }
        public override string ToString()
        {
            return $"Pupil: {this.FullName}\nAge: {this.Age}\nGrade: {this.GradeOfScholl}";
        }
    }
    class Teacher : Person
    {
        private string Subject { get; set; }

        public Teacher(string firstName, string lastName, int yearOfBirth) : base(firstName, lastName, yearOfBirth)
        {
        }

    }
    class Class
    {
        public string Grade { get; set; }

        public Class(string grade)
        {
            Grade = grade;
            new List<Pupil>();
        }
    }
    //class Subject
    //{
    //   enum Subjects { Chemistry=0, Physics=1, Biology=2, Algebra=0 }; 

    //}
    static void Main()
    {

        //var p = new Pupil("Jonh", "Smith", 2010);

        //Console.WriteLine(p);

        var s = new Schedule(5);

        s.PrintSchedule();



    }






}