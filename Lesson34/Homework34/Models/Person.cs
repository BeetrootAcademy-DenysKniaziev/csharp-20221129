using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Homework34.Models
{
    public class Person
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        //[PasswordPropertyText]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

        [Phone]
        public string? Phone { get; set; }

        //public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}

