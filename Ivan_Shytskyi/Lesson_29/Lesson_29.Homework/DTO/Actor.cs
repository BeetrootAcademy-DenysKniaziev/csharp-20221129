using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29.Homework.DTO
{
    [Table("actors", Schema = "public")]
    public class Actor
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

        [Column("list_actor_id")]
        [Required]
        public int ListActorId { get; set; }

        public virtual ListActor ListActor { get; set; }

    }
}
