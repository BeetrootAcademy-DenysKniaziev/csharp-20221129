
    static void Main(String[] args)
    {
        var firstStudent = new Student
        {
            FirstName = "Vitaliy",
            LastName = "Zakarevskyi",
        };
       
    }
    class Book
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int YearOfPublishing { get; set; }
    }

    class Librarian
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int WorkExperience { get; set; }
    }

    class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Faculty { get; set; } 

    }

