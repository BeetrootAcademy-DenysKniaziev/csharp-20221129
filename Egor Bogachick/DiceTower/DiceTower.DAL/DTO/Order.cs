using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiceTower.DAL.DTO
{
    [Table("order", Schema = "public")]
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("person_id")]
        [Required]
        public int PersonId { get; set; }

        [ForeignKey("product_id")]
        [Required]
        public int ProductId { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        public User User { get; set; }

        public Product Product { get; set; }


    }
}
