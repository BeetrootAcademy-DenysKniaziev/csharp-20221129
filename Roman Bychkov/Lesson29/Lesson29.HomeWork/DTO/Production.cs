
namespace Lesson29.HomeWork.DTO
{
    [Table("production", Schema = "public")]
    internal class Production
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name_production")]
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Column("year_of_created")]
        [Required]
        public DateTime YearOfCreated { get; set; }
        public List<Film> Films { get; set; } = new();
    }
}
