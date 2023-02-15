
namespace Lesson29.HomeWork.DTO
{
    [Table("genre", Schema = "public")]
    internal class Genre
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }
        public List<Film> Films { get; set; } = new();
    }
}
