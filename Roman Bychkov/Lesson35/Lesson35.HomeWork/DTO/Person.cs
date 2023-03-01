
using Newtonsoft.Json;

namespace DataBase.DTO
{
    [Table("persons", Schema = "public")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        [JsonProperty("id")]
        public int Id { get; set; }

        [Column("first_name")]
        [MaxLength(100)]
        [Required]
        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [Column("last_name")]
        [MaxLength(100)]
        [Required]
        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [Column("age")]
        [Required]
        [JsonProperty("age")]
        public int Age { get; set; }

        [Column("gender")]
        [MaxLength(1)]
        [Required]
        [JsonProperty("gender")]
        public string Gender { get; set; }

        [Column("address")]
        [JsonProperty("address")]
        public string Address { get; set; }

        public virtual List<Order> Orders { get; set; }

        public override string ToString()
        {
            return FirstName + " " + LastName + " " + Age + " " + Gender + " " + Address;
        }
    }
}
