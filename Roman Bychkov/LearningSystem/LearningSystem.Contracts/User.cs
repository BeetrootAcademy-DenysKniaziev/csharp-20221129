
namespace LearningSystem.Contracts
{
    [Table("users", Schema = "public")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("user_name")]
        public string UserName { get; set; }

        [StringLength(70]
        [Required]
        [Column("image")]
        public string Image { get; set; }

        [DataType(DataType.Password)]
        [StringLength(50, MinimumLength = 3)]
        [Column("password")]
        public string Password { get; set; }

        [Column("created")]
        public DateTime Created { get; } = DateTime.Now;

        [Required]
        [EmailAddress]
        [Column("mail")]
        public string Email { get; set; }

    }
}