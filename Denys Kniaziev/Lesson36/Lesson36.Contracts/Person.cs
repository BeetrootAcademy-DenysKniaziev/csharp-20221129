using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson36.Contracts
{
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        public bool Verified { get; set; }
        
        public string Email { get; set; }

        public byte Age { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
