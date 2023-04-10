
namespace LearningSystem.Contracts
{
    [Table("like_article", Schema = "public")]
    public class LikeArticle : IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        
        [ForeignKey("user_id")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("article_id")]
        [Required]
        public int ArticleId { get; set; }

        public virtual User User { get; set; }
        public virtual Article Article { get; set; }
    }
}
