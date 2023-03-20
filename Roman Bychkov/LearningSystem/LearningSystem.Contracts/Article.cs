
namespace LearningSystem.Contracts
{
    [Table("arcticles", Schema = "public")]
    public class Article: IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("arcticle_name")]
        public string ArcticleName { get; set; }

        
        [Required]
        [Column("number")]
        public byte Number { get; set; }

       
        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Column("course_id")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual List<LikeArticle> Likes { get; set; } = new List<LikeArticle>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
