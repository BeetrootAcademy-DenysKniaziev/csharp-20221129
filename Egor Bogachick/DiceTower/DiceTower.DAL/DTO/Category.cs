using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiceTower.DAL.DTO
{
    [Table("category", Schema = "public")]
    public class Category
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Column("category_name")]
        [MaxLength(100)]
        [Required]
        public string CategoryName { get; set; }

        [Column("description")]
        [MinLength(10)]
        public string Description { get; set; }

        public virtual List<Product> Products { get; set; }
    }
}
