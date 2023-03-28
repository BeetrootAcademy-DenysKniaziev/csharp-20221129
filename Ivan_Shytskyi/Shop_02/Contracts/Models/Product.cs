using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    [Table("products", Schema = "public")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [Required]
        public string Description { get; set; }

        [Column("price")]
        [Required]
        public decimal Price { get; set; }

        [Column("in_stock")]
        [Required]
        public Boolean InStock { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {InStock}";
        }
    }
}
