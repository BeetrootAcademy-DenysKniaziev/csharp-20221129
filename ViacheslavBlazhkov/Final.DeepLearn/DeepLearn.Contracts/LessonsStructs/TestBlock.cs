using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.Contracts.LessonsStructs
{
    [Table("test_blocks")]
    public class TestBlock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("question")]
        public string Question { get; set; }

        [Required]
        [Column("theory_block_id")]
        [ForeignKey("TheoryBlock")]
        public int TheoryBlockId { get; set; }

        public TheoryBlock TheoryBlock { get; set; }

        public ICollection<Answer> Answers { get; set; }

        public int? SelectedAnswerId { get; set; }
    }
}
