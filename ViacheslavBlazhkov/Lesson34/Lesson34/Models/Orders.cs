using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lesson34.Models
{
    public class Orders
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ProductId { get; set; }
        public int ProductCount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public double TotalPrice { get; set; }
        [DataType(DataType.Date)]
        public DateTime OrderDate { get; set; }
    }
}
