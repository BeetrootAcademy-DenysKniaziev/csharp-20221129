
//namespace Lesson10.Homework
//{using System;
//    using System.Reflection.Emit;

//    internal class Program
//    {
//        static void Main(string[] args)
//        {

//            var p1 = new Subscriber("Ivan Petrenko", 2, 80);

//            Console.WriteLine(p1);

//            p1.Age = 22;

//            Console.WriteLine(p1);
            
            
//            //Console.WriteLine("Hello, World!");

//        }

//        class Adresess
//        {
//            public string City { get; set; }

//            public string Street { get; set;}

//            public int HouseNumber { get; set; }

//        }

//        class Booking
//        {
//            public int GetBook()
//            {
//                return Subscriber.QuantiityBooks++;

//            }


//        }


//        class Lybrary
//        {
//            public const int DefaultQuantityBooks = 100;
           
//            public Adresess Adresess { get; set; }

//            public int QuantityBooks 
//            {
//                get { return DefaultQuantityBooks; }
//                set { QuantityBooks = value; }
//            }

//            public int QuantityUsers;

//            public int ProvideBook()
//            {
//                return QuantityBooks--;

//            }

//            class Book
//            {
//                public string Author { get; set; }

//                public string Title { get; set; }

//                public string Condition { get; set; }

//                public string Genre { get; set; }
//            }


//        }


               
//        class Subscriber
//        {
//            public const int DefaultAge = 18;

         
//            public string Name { get; set; }

//            public int Age
//            {
//                get { return DefaultAge; }
//                set { Age = value; }
//            }

//            public int QuantiityBooks { get; set; }

            
//            public Subscriber(string name, int age, int quantiityBooks)
//            {
//                Name = name;
//                Age = age;
//                QuantiityBooks = quantiityBooks;
//                            }
//            public Subscriber(string name, int quantiityReadBooks)
//            {
//                Name = name;
//                QuantiityBooks = quantiityReadBooks;
//             }

//            public void GetBook()
//            {
//                QuantiityBooks++;
                
//            }

//            public override string ToString()
//            {
//                return
//                    $"Fullname:{Name}\nAge:{Age}\nNamber of books: {QuantiityBooks}";

//            }

//        }


//    }

//}
