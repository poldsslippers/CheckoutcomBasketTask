using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketClassLibrary
{
    /// <summary>
    /// Interface for product
    /// </summary>
    interface IProduct
    {
        int Id { get; set; }
        string Name { get; set; }
        double Price { get; set; }
        
    }

}
