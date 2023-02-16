using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson29.Classwork.DTO
{
    [Table("orders", Schema = "public")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("person_id")]
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("product_id")]
        [Required]
        public int ProductId { get; set; }

        [Column("order_time")]
        [Required]
        public DateTime OrderTime { get; set; }

        public virtual Person Person { get; set; }

        public virtual Product Product { get; set; }
    }
}
