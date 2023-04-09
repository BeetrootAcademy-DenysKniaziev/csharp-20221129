using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Contracts.Models
{
    [Table("user", Schema = "public")]
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Column("user_name")]
        [MaxLength(255)]
        [Required]
        public string UserName { get; set; }

        [Column("address")]
        public string Address { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("phone_number")]
        public string PhoneNumber { get; set; }

        public virtual List<Order> Orders { get; set; }

        [Column("password_salt")]
        public byte[] PasswordSalt { get; set; }

        [Column("password_hash")]
        public byte[] PasswordHash { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Email + " " + PhoneNumber + " " + Address;
        }
    }
}
