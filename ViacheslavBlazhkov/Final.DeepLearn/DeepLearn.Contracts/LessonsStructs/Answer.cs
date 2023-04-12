using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeepLearn.Contracts.LessonsStructs
{
    [Table("answers")]
    public class Answer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("text")]
        public string Text { get; set; }

        [Required]
        [Column("is_correct")]
        public bool IsCorrect { get; set; }

        [Required]
        [ForeignKey("TestBlock")]
        [Column("test_block_id")]
        public int TestBlockId { get; set; }

        public TestBlock TestBlock { get; set; }
    }

}
