
namespace LearningSystem.Contracts
{
    [Table("comment", Schema = "public")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("created")]
        public DateTime Created { get; } = DateTime.UtcNow;

        [ForeignKey("user_id")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("article_id")]
        [Required]
        public int ArticleId { get; set; }

        public virtual User User { get; set; }

        public virtual Arcticle Arcticle { get; set; }

        public virtual List<LikeComment> LikeComments { get; set; }
    }
}
