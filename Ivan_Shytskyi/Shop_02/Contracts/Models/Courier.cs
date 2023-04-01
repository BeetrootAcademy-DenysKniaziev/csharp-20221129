using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    [Table("courier", Schema = "public")]
    public class Сourier
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
        [Required]
        public string PhoneNumber { get; set; }

        //public byte[] PasswordSalt { get; set; }
        //public byte[] PasswordHash { get; set; }

        public virtual List<Order> Orders { get; set; }
    }
}
