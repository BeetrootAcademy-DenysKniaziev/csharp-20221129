using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson35.Models
{
    [Table("orders")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [ForeignKey("person_id")]
        [Column("person_id")]
        public int PersonId { get; set; }

        [Required]
        [ForeignKey("product_id")]
        [Column("product_id")]
        public int ProductId { get; set; }

        [Required]
        [Column("order_time")]
        public DateTime OrderDate { get; set; }

        public virtual Person? Person { get; set; }
        public virtual Product? Product { get; set; }
    }
}
