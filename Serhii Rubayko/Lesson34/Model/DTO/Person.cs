using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson34.Model.DTO
{
    [Table("persons", Schema = "public")]
    public class Person
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

        [Column("gender")]
        [MaxLength(1)]
        [Required]
        public string Gender { get; set; }

        [Column("address")]
        public string Address { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Age + " " + Gender + " " + Address;
        }
    }
}
