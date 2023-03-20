
namespace LearningSystem.Contracts
{
    [Table("users", Schema = "public")]
    public class User : IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("user_name")]
        public string UserName { get; set; }

        [StringLength(80)]
        [Column("image")]
        public string Image { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("created")]
        public DateTime Created { get; } = DateTime.UtcNow;

        [Required]
        [EmailAddress]
        [Column("mail")]
        public string Email { get; set; }

        public virtual List<LikeArticle> LikeArticles { get; set;} = new List<LikeArticle>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<LikeComment> LikeComments { get; set; } = new List<LikeComment>();

    }
}