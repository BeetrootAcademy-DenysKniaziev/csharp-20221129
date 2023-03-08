using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson29.Models
{
    [Table("movies", Schema = "public")]
    internal class Movie
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        [MinLength(1)]
        [Required]
        public string Title { get; set; }

        [ForeignKey("genre_id")]
        public int GenreId { get; set; }

        [DataType(DataType.Date)]
        [Column("release_date")]
        public DateTime ReleaseDate { get; set; }

        [Range(0, 999.99)]
        public decimal Rating { get; set; }

        public bool IsPremium { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
