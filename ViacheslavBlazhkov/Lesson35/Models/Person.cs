using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson35.Models
{
    [Table("people")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("first_name")]
        public string? FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        [Column("last_name")]
        public string? LastName { get; set; }

        [Required]
        [Phone]
        [Column("phone")]
        public string? Phone { get; set; }

        [EmailAddress]
        [Column("email")]
        public string? Email { get; set; }

        [Column("address")]
        public string? Address { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
