using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework29.DTO
{
    [Table("awarding_competitiors", Schema = "public")]
    public class AwardingCompetitiors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("awarding_id")]
        [Required]
        public int AwardingId { get; set; }

        [ForeignKey("actor_id")]
        [Required]
        public int ActorId { get; set; }

        public virtual Actor Actor { get; set; }
        public virtual Awarding Awarding { get; set; }
    }
}
