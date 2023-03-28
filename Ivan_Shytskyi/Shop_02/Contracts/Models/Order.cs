using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Contracts.Models
{
    [Table("orders", Schema = "public")]
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("recipient_id")]
        [Required]
        public int UserId { get; set; }

        [Column("courier_id")]
        [Required]
        public int СourierId { get; set; }

        [Column("product_id")]
        [Required]
        public int ProductId { get; set; }

        [Column("order_time")]
        [Required]
        public DateTime OrderTime { get; set; }

        //[Column("order_status")]
        //[Required]
        //public string OrderStatus { get; set; }

        [Column("is_delivered")]
        [Required]
        public bool IsDelivered { get; set; } = false;

        [Column("is_received")]
        [Required]
        public bool IsReceived { get; set; } = false;

        //[Column("is_picked_up")]
        //[Required]
        //public bool IsPickedUp { get; set; }

        public virtual User User { get; set; }

        public virtual Product Product { get; set; }
    }
}
