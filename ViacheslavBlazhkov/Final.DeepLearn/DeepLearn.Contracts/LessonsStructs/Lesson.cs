using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.Contracts.LessonsStructs
{
    [Table("lessons")]
    public class Lesson
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string Title { get; set; }

        [Required]
        [ForeignKey("Module")]
        [Column("module_id")]
        public int ModuleId { get; set; }

        public Module Module { get; set; }

        public ICollection<TheoryBlock> TheoryBlocks { get; set; }
    }
}
