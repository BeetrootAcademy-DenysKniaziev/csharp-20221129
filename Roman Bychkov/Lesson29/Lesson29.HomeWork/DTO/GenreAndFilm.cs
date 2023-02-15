
namespace Lesson29.HomeWork.DTO
{
    [Table("genre_film", Schema = "public")]
    internal class GenreAndFilm
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("film_id")]
        public int FilmId { get; set; }

        [Required]
        [ForeignKey("genre_id")]
        public int GenreId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
