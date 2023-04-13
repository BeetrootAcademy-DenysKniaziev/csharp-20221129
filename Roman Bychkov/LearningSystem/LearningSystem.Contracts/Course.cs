
using Microsoft.MarkedNet;
using System.Text.RegularExpressions;

namespace LearningSystem.Contracts
{
    [Table("courses", Schema = "public")]
    public class Course : IEntityWithId
    {
      
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("course_name")]
        public string CourseName { get; set; }

        [StringLength(100)]
        [Required]
        [Column("image_path")]
        public string ImagePath { get; set; }

        [StringLength(200)]
        [Required]
        [Column("description")]
        public string Description { get; set; }

        [ForeignKey("user_id")]
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Column("content")]
        [Required]
        [StringLength(10000)]
        public string Content { get; set; }

        [NotMapped]
        private static Marked Marked = new Marked();
        [NotMapped]
        public string ContentHTML
        {
            get => Marked.Parse(RemoveUnsafeTags(Content));
        }
        [Column("created")]
        [Required]
        public DateTime Created { get; set; } = DateTime.UtcNow;

        public virtual List<Article> Articles { get; set; } = new List<Article>();
        private string RemoveJavascript(string html)
        {
            html = Regex.Replace(html, "<script.*?</script>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            html = Regex.Replace(html, "javascript:", string.Empty, RegexOptions.IgnoreCase);

            return html;
        }
        private string RemoveUnsafeTags(string html)
        {
            html = Regex.Replace(html, @"<(img|script|iframe|object|embed)(?:(?!\b```\b)[^>])*>", string.Empty, RegexOptions.IgnoreCase | RegexOptions.Singleline);

            return html;
        }
    }

}
