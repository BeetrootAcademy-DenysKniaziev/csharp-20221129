using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiceTower.DAL.DTO
{
    [Table("producer", Schema = "public")]
    public class Producer
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

        public virtual List<Product> Products { get; set; }

    }
}
