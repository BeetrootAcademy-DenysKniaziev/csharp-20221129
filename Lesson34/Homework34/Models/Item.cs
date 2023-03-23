using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework34.Models
{
    public class Item
    {
        public int ItemID { get; set; }
        //public int OrderID { get; set; }//?? Nafiga ya yogo dodav? Vin i tak lezhyt` v kollekcii yakogos` Ordera. 
        public int TagID { get; set; }

        public int Amount { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; } //If null image goes from Tag Image

        public virtual Tag Tag { get; set; }
        //public virtual Order Order { get; set; }//?? Tut analogichno
    }
}
