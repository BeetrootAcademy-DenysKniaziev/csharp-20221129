
namespace LearningSystem.Contracts
{
    [Table("like_article", Schema = "public")]
    public class LikeArticle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        public bool Liked { get; set; } = false;

        [ForeignKey("user_id")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("article_id")]
        [Required]
        public int ArticleId { get; set; }

        public virtual User User { get; set; }
        public virtual Arcticle Arcticle { get; set; }
    }
}
