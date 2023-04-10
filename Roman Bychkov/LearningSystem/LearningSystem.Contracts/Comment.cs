
namespace LearningSystem.Contracts
{
    [Table("comment", Schema = "public")]
    public class Comment : IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("created")]
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [ForeignKey("user_id")]
        [Required]
        public int UserId { get; set; }

        [Required]
        [Column("content")]
        [StringLength(250, MinimumLength = 1)]
        public string Content { get; set; }

        [ForeignKey("article_id")]
        [Required]
        public int ArticleId { get; set; }



        public virtual User User { get; set; }

        public virtual Article Article { get; set; }

        public virtual List<LikeComment> LikeComments { get; set; } = new List<LikeComment>();
    }
}
