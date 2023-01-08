using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework13
{
    internal class Session    {
        public int CurrentProduct { get; set; }
        public Buyers Buyer = new();
        public TheCart cart = new();
    }
}
