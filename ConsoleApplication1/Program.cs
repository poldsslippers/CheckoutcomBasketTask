using BasketClassLibrary;
using BasketEndPointClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        /// <summary>
        /// Test program using BasketEndPointLibrary to 
        /// Create a basket
        ///  add products
        ///  remove a product
        ///  clear the basket
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BasketEndPointsHandler handler = new BasketEndPointsHandler("http://localhost:1100");

            //create a basket
            Basket basket = handler.CreateBasket();
            Console.WriteLine("----------Create Basket-------------");

            //display basket
            showBasket(basket);

            Console.WriteLine("----------Added Products to Basket-------------");
            //add three products
            handler.AddProductToBasket(1, basket.Id);
            handler.AddProductToBasket(2, basket.Id);
            handler.AddProductToBasket(3, basket.Id);
            

            // get the basket you have just added 3 products to
            basket = handler.GetBasket(basket.Id);

            //show basket
            showBasket(basket);

            Console.WriteLine("----------Remove a Product-------------");
            handler.RemoveProductFromBasket(basket.Id, 2);
            
            // get the basket you have just added 3 products to
            basket = handler.GetBasket(basket.Id);

            //show basket
            showBasket(basket);
            
            Console.WriteLine("----------Clear Basket-------------");
            handler.ClearBasket(basket);
                        
            // get the basket you have just cleared
            basket = handler.GetBasket(basket.Id);

            //show it has been cleared
            showBasket(basket);

            Console.ReadLine();
        }

        public static void showBasket(Basket basket)
        {
            Console.WriteLine("Basket Details");
            if (basket != null)
            {
                Console.WriteLine("Basket ID:" + basket.Id);
                Console.WriteLine("Basket User ID:" + basket.UserId);
                Console.WriteLine("Products in Basket:" + basket.BasketProducts.Count());
                foreach(BasketProduct bp in basket.BasketProducts)
                {
                    Console.WriteLine("product name:" + bp.Name);
                }                
            }
            else
            {
                Console.WriteLine("Basket is null");
            }
        }
    }
}
