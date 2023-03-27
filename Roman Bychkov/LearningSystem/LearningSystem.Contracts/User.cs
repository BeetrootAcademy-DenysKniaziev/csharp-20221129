
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

      
        [Column("image")]
        public string Image { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("password")]
        public string Password { get; set; }

        [Column("created")]
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        [Required]
        [EmailAddress]
        [Column("mail")]
        public string Email { get; set; }

        public virtual List<LikeArticle> LikeArticles { get; set;} = new List<LikeArticle>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();
        public virtual List<LikeComment> LikeComments { get; set; } = new List<LikeComment>();

        public virtual List<Course> Courses { get; set; } = new List<Course>();

    }
}