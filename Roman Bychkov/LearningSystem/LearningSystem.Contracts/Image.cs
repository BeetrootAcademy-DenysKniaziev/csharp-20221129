
namespace LearningSystem.Contracts
{
    [Table("images", Schema = "public")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50)]
        [Required]
        [Column("image_name")]
        public string ImageName { get; set; }

        [StringLength(100)]
        [Required]
        [Column("path")]
        public string Path { get; set; }


        public virtual List<Article> Articles { get; set; }

    }
}
