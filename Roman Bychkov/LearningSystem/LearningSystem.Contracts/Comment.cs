
namespace LearningSystem.Contracts
{
    [Table("comment", Schema = "public")]
    public class Comment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


    }
}
