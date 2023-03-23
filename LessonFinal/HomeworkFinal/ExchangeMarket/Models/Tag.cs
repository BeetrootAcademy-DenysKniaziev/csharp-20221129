using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExchangeMarket.Models
{
    public class Tag
    {
        public int TagID { get; set; }
        public string TagName { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } //If null image goes from Tag Image
    }
}
