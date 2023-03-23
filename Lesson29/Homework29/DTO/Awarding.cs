using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework29.DTO
{
    [Table("awardings", Schema = "public")]
    public class Awarding
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("casting_id")]
        [Required]
        public int CastingId { get; set; }

        //[ForeignKey("film_id")]
        //[Required]
        //public int FilmId { get; set; }

        //[ForeignKey("film_id")]
        //[Required]
        //public int FilmId { get; set; }

        [ForeignKey("award_id")]
        [Required]
        public int AwardId { get; set; }

        [Column("date_of_awarding")]
        [Required]
        public DateTime DateOfAwarding { get; set; }

        //public virtual Actor Actor { get; set; }
        //public virtual Film Film { get; set; }
        public virtual Casting Casting { get; set; }
        public virtual Award Award { get; set; }


    }
}
