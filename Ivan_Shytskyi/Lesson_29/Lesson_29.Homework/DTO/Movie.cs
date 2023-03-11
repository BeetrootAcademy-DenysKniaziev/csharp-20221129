using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_29.Homework.DTO
{
    [Table("movies", Schema = "public")]
    public class Movie 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("genre")]
        [MaxLength(100)]
        [Required]
        public string Genre { get; set; }

        [Column("release_date")]
        [Required]
        public DateOnly ReleaseDate { get; set; }

        [Column("rating")]
        [MaxLength(100)]
        [Required]
        public int Rating { get; set; }

        [Column("country")]
        [MaxLength(255)]
        [Required]
        public string Country { get; set; }

        [Column("list_actor_id")]
        [Required]
        public int ListActorId { get; set; }

        [Column("producer_id")]
        [Required]
        public int ProducerId { get; set; }

        [Column("studio_id")]
        [Required]
        public int StudioId { get; set; }

        public virtual Producer Producer { get; set; }
        public virtual Studio Studio { get; set; }
        public virtual ListActor ListActor { get; set; }

        public override string ToString()
        {
            return $"{Name} {Genre} {ReleaseDate}";
        }
    }
}
