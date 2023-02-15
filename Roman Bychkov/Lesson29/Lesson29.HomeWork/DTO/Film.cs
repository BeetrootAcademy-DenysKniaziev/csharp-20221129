

namespace Lesson29.HomeWork.DTO
{
    [Table("films",Schema = "public")]
    internal class Film
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Column("budget")]
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Budget { get; set; }

        [Required]
        [ForeignKey("production_id")]
        public int ProductionId { get; set; }

        public virtual Production Production { get; set; }

        public List<Genre> Genres { get; set; } = new();
        public List<Actor> Actors { get; set; } = new();

        public override string ToString()
        {
            return Name;
        }
    }
}
