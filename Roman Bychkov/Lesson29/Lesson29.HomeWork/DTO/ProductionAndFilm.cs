


namespace Lesson29.HomeWork.DTO
{
    // This
    [Table("production_film", Schema = "public")]
    internal class ProductionAndFilm
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("film_id")]
        public int FilmId { get; set; }

        [Required]
        [ForeignKey("production_id")]
        public int ProductionId { get; set; }

        public virtual Film Film { get; set; }
        public virtual Production Production { get; set; }

    }
}
