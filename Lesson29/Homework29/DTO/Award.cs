using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework29.DTO
{
    [Table("awards", Schema = "public")]
    public class Award
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("award_name")]
        [MaxLength(100)]
        [Required]
        public string AwardName { get; set; }


        [Column("category")]
        [MaxLength(100)]
        [Required]
        public string Category { get; set; }
    }
}
