
namespace LearningSystem.Contracts
{
    [Table("like_comment", Schema = "public")]
    public class LikeComment : IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

      
        [ForeignKey("user_id")]
        [Required]
        public int UserId { get; set; }

        [ForeignKey("comment_id")]
        [Required]
        public int CommentId { get; set; }

        public virtual User User { get; set; }
        public virtual Comment Comment { get; set; }
    }
}
