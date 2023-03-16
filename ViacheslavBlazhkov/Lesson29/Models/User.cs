using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson29.Models
{
    [Table("users", Schema = "public")]
    internal class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(20)]
        [MinLength(2)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(20)]
        [MinLength(2)]
        [Required]
        public string LastName { get; set; }

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public int AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
