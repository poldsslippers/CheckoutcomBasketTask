using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketClassLibrary
{
    public class Basket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public HashSet<BasketProduct> BasketProducts { get; set; }

        public Basket()
        {
            this.BasketProducts = new HashSet<BasketProduct>();
        }
    }
}
