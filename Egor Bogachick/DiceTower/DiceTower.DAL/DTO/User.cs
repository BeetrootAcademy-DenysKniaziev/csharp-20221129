using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiceTower.DAL.DTO
{
    [Table("user", Schema = "public")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("password")]
        [MaxLength(40)]
        [Required]
        public string Password { get; set; }

        [Column("adress")]
        public string Adress { get; set; }

        [Column("phone_numebr")]
        public string PhoneNumebr { get; set; }

        [Column("role")]
        public string Role { get; set; }

        public virtual List<Order> Orders { get; set; }


    }
}
