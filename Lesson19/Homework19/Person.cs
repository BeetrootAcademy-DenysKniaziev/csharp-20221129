using Homework19;
using System;

namespace Homework19
{
    public enum Gender
    {
        Male,
        Female
    }

    public class Friend
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Person
    {
        public string Id { get; set; }
        public int Index { get; set; }
        public Guid Guid { get; set; }
        public bool IsActive { get; set; }
        public string Balance { get; set; }
        public int Age { get; set; }
        public string EyeColor { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string About { get; set; }
        public DateTime Registered { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string[] Tags { get; set; }
        public Friend[] Friends { get; set; }

        public double Position(Person p1)//fi- latitude l- longitude
        {
            double fi1 = p1.Latitude;
            double l1 = p1.Longitude;
            double fi2 = this.Latitude;
            double l2 = this.Longitude;
            double x, y, z;
            x = Math.Cos(fi2) * Math.Cos(l2) - Math.Cos(fi1) * Math.Cos(l1);
            y = Math.Cos(fi2) * Math.Sin(l2) - Math.Cos(fi1) * Math.Sin(l1);
            z = Math.Sin(fi2) - Math.Sin(fi1);
            double c = Math.Sqrt(x * x + y * y + z * z);
            return c;
        }
    }
}

