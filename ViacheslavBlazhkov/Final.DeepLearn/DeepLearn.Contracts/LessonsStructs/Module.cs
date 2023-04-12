using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.Contracts.LessonsStructs
{
    [Table("modules")]
    public class Module
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [Column("course_id")]
        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        public ICollection<Lesson> Lessons { get; set; }
    }
}
