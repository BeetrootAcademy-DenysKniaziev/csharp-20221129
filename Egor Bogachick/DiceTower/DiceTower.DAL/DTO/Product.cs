using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiceTower.DAL.DTO
{
    [Table("product", Schema = "public")]
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("name")]
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Column("description")]
        [MinLength(10)]
        public string Description { get; set; }

        [Column("price")]
        [Required]
        public decimal Price { get; set; }

        [Column("in_stock")]
        [Required]
        public bool InStock { get; set; }

        [ForeignKey("category_id")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("producer_id")]
        [Required]
        public int ProducerId { get; set; }

        public Producer Producer { get; set; }
        public Category Category { get; set; }
        public List<Order> Orders { get; set; }
    }
}
