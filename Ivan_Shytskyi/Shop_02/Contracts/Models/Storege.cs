using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
