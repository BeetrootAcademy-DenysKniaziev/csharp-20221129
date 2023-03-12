//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Data.Entity;
//using Homework34.Models;

//namespace Homework34.DAL
//{
//    public class MarketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MarketContext>
//    {
//        protected override void Seed(MarketContext context)
//        {
//            var persons = new List<Person>
//            {
//            new Person{FirstMidName="Carson",LastName="Alexander",EnrollmentDate=DateTime.Parse("2005-09-01")},
//            new Person{FirstMidName="Meredith",LastName="Alonso",EnrollmentDate=DateTime.Parse("2002-09-01")},
//            new Person{FirstMidName="Arturo",LastName="Anand",EnrollmentDate=DateTime.Parse("2003-09-01")},
//            new Person{FirstMidName="Gytis",LastName="Barzdukas",EnrollmentDate=DateTime.Parse("2002-09-01")},
//            new Person{FirstMidName="Yan",LastName="Li",EnrollmentDate=DateTime.Parse("2002-09-01")},
//            new Person{FirstMidName="Peggy",LastName="Justice",EnrollmentDate=DateTime.Parse("2001-09-01")},
//            new Person{FirstMidName="Laura",LastName="Norman",EnrollmentDate=DateTime.Parse("2003-09-01")},
//            new Person{FirstMidName="Nino",LastName="Olivetto",EnrollmentDate=DateTime.Parse("2005-09-01")}
//            };

//            persons.ForEach(s => context.Persons.Add(s));
//            context.SaveChanges();
//            var orders = new List<Order>
//            {
//            new Order{Title="A lot of ground",Credits=30},
//            new Order{Title="Plumbering",Credits=10},
//            new Order{Title = "Timber in stock", Credits = 20 }
//            };
//            orders.ForEach(s => context.Orders.Add(s));
//            context.SaveChanges();
//            var enrollments = new List<Enrollment>
//            {
//            new Enrollment{PersonID=1,OrderID=1,Grade=Grade.Standard},
//            new Enrollment{PersonID=2,OrderID=2}
//            };
//            enrollments.ForEach(s => context.Enrollments.Add(s));
//            context.SaveChanges();
//        }
//    }
//}