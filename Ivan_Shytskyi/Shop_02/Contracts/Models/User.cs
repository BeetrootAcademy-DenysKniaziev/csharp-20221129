using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Contracts.Models
{
    [Table("user", Schema = "public")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [MaxLength(100)]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(100)]
        [Required]
        public string LastName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("phone_number")]
        [Required]
        public string PhoneNumber { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email + " " + PhoneNumber + " " + Address;
        }
    }
}
