using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketClassLibrary
{
    public interface IBasketDataStore
    {
        
        /// <summary>
        ///  Add Product 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        Product AddProduct(Product p);
        
        /// <summary>
        /// Delete Product by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteProduct(int id);
        
        /// <summary>
        /// Get All Products
        /// </summary>
        /// <returns></returns>
        List<Product> GetProducts();

        /// <summary>
        /// Get Product by Id
        /// </summary>
        /// <returns></returns>
        Product GetProduct(int id);

        /// <summary>
        /// Create a basket
        /// </summary>
        /// <returns></returns>
        Basket CreateBasket(int userID);

        /// <summary>
        /// Get Basket by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Basket GetBasket(int id);

        /// <summary>
        /// update a whole basket
        /// </summary>
        /// <param name="basket"></param>
        void UpdateBasket(Basket basket);

        /// <summary>
        /// Clear contents of basket
        /// </summary>
        /// <param name="id"></param>
        void ClearBasket(int id);

        /// <summary>
        /// Delete basket by id
        /// </summary>
        /// <param name="id"></param>
        void DeleteBasket(int id);

        /// <summary>
        /// Add product to a basket by id
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="productId"></param>
        void AddProductToBasket(int basketId, int productId);

        /// <summary>
        /// Add product to basket 
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="basketProduct"></param>
        void AddProductToBasket(int basketId, BasketProduct basketProduct);

        /// <summary>
        /// Remove a product from the basket
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="productId"></param>
        void RemoveProductFromBasket(int basketId, int productId);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="basketProduct"></param>
        void UpdateProductInBasket(int basketId, BasketProduct basketProduct);

    }
}
