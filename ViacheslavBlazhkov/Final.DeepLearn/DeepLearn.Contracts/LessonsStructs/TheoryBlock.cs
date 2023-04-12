using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.Contracts.LessonsStructs
{
    [Table("theory_blocks")]
    public class TheoryBlock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; }

        [Required]
        [Column("lesson_id")]
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }

        public Lesson Lesson { get; set; }

        public TestBlock TestBlock { get; set; }
    }
}
