namespace Lesson29.HomeWork.DTO
{
    [Table("roles", Schema = "public")]
    internal class Role
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Column("name")]
        [Required]
        [MaxLength(35)]
        public string Name { get; set; }


        [Required]
        [ForeignKey("role_id")]
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        [Required]
        [ForeignKey("film_id")]
        public int FilmId { get; set; }
        public virtual Film Film { get; set; }

    }
}
