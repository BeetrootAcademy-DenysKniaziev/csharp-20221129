
namespace Lesson29.HomeWork.DTO
{
    [Table("actor", Schema = "public")]
    internal class Actor
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }

        [Column("last_name")]
        [Required]
        [MaxLength(35)]

        public string LastName { get; set; }

        [Column("gender")]
        [Required]
        public char Gender { get; set; }

        [Column("role")]
        [Required]
        [MaxLength(60)]
        public string Role { get; set; }

        [Column("birthday")]
        [Required]
        public DateTime Birthday { get; set; }

        [Column("date_death")]
        public DateTime? DateDeath { get; set; }

        public List<Film> Films { get; set; } = new();
    }
}
