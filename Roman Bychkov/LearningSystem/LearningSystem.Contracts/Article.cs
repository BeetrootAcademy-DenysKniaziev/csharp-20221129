
using Microsoft.MarkedNet;
using System.Text.RegularExpressions;

namespace LearningSystem.Contracts
{
    [Table("articles", Schema = "public")]
    public class Article: IEntityWithId
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("article_name")]
        public string ArticleName { get; set; }

        
        [Required]
        [Column("number")]
        public byte Number { get; set; }

        [Required]
        [StringLength(10000)]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Column("course_id")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual List<LikeArticle> Likes { get; set; } = new List<LikeArticle>();
        public virtual List<Comment> Comments { get; set; } = new List<Comment>();

        [NotMapped]
        private static Marked Marked = new Marked();
        [NotMapped]
        public string ContentHTML
        {
            get => Marked.Parse(RemoveUnsafeTags(Content));
        }
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
