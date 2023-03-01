namespace DataBase.DTO
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

        [Column("discounted_price")]
        [Required]
        public decimal DiscountedPrice { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name} {Description} {Price} {DiscountedPrice}";
        }
    }
}
