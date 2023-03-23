using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public class Person : IdentityUser<int>
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        //[EmailAddress]
        //public string Email { get; set; }

        //[PasswordPropertyText]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //[Phone]
        //public string? Phone { get; set; }
        
        //public int AccessFailedCount { get; set; }

        ////public DateTime EnrollmentDate { get; set; }

        public virtual ICollection<Enrollment>? Enrollments { get; set; }
    }
}
