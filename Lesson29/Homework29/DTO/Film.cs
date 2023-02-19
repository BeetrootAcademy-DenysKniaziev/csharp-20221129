using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework29.DTO
{
    [Table("films", Schema = "public")]
    public class Film
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("film_name")]
        [MaxLength(50)]
        [Required]
        public string FilmName { get; set; }

        [Column("date_of_production")]
        public DateTime DateOfProduction { get; set; }
    }
}
