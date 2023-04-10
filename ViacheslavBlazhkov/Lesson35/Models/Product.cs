using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson35.Models
{
    [Table("products")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("title")]
        public string? Title { get; set; }

        [Column("description", TypeName = "ntext")]
        public string? Description { get; set; }

        [Required]
        [Column("price", TypeName = "decimal(10, 2)")]
        public decimal Price { get; set; }

        public List<Order>? Orders { get; set; }
    }
}
