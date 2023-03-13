namespace LearningSystem.Contracts
{
    [Table("arcticles", Schema = "public")]
    public class Arcticle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }


        [StringLength(50, MinimumLength = 3)]
        [Required]
        [Column("arcticle_name")]
        public string ArcticleName { get; set; }

        //[StringLength(50)]
        //[Required]
        //[Column("arcticle_view")]
        //public string ArcticleView { get; set; }

        public virtual Course Course { get; set; }
        public virtual List<LikeArticle> Likes { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Image> Images { get; set; }
    }
}
