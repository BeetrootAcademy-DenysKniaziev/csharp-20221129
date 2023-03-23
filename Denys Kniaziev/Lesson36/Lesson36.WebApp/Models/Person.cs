using System.ComponentModel.DataAnnotations;

namespace Lesson36.WebApp.Models
{
    public class Person
    {
        public int Id { get; set; }

        [StringLength(10)]
        public string FirstName { get; set; }

        [StringLength(10)]
        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public bool Verified { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public byte Age { get; set; }
    }
}
