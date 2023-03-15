
namespace LearningSystem.Contracts
{
    [Table("courses", Schema = "public")]
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("course_name")]
        public string CourseName { get; set; }

        [StringLength(100)]
        [Required]
        [Column("image_path")]
        public string ImagePath { get; set; }

        [StringLength(200)]
        [Required]
        [Column("description")]
        public string Description { get; set; }

        
        [Column("content")]
        public string Content { get; set; }

        [Column("created")]
        public DateTime Created { get; } = DateTime.UtcNow;

        public virtual List<Article> Articles { get; set; }

    }
}
