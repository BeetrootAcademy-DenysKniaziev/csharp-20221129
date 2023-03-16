﻿namespace LearningSystem.Contracts
{
    [Table("arcticles", Schema = "public")]
    public class Article
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("arcticle_name")]
        public string ArcticleName { get; set; }

        
        [Required]
        [Column("number")]
        public int Number { get; set; }

       
        [Required]
        [Column("content")]
        public string Content { get; set; }

        [Required]
        [Column("course_id")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual List<LikeArticle> Likes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
