using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Models
{
    [Table("storege", Schema = "public")]
    public class Storege
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("address")]
        [Required]
        public string Address { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
