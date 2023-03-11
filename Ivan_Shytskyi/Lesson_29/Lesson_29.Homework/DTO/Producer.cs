using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson_29.Homework.DTO
{
    [Table("producers", Schema = "public")]
    public class Producer 
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

        [Column("age")]
        [Required]
        public int Age { get; set; }
    }
}
