using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasketClassLibrary
{
    public class MockDatabase : IBasketDataStore
    {

        /// <summary>
        /// Quick and dirty, this is just a way to persist data and manipulate it without havinga database
        /// </summary>

        private static MockDatabase instance;
        private static List<Product> _products;
        private static Dictionary<int, Basket> _baskets;



        private MockDatabase()
        {
            _products = new List<Product>();
            // set up some basic products
            _products.Add(new Product { Id = 1, Name = "Product 1", Price = 10 });
            _products.Add(new Product { Id = 2, Name = "Product 2", Price = 20 });
            _products.Add(new Product { Id = 3, Name = "Product 3", Price = 30 });
            _products.Add(new Product { Id = 4, Name = "Product 4", Price = 40 });
            _products.Add(new Product { Id = 5, Name = "Product 5", Price = 50 });
            _products.Add(new Product { Id = 6, Name = "Product 6", Price = 60 });
            _products.Add(new Product { Id = 7, Name = "Product 7", Price = 70 });
            _products.Add(new Product { Id = 8, Name = "Product 8", Price = 80 });
            _products.Add(new Product { Id = 9, Name = "Product 9", Price = 90 });
            _products.Add(new Product { Id = 10, Name = "Product 10", Price = 100 });

            _baskets = new Dictionary<int, Basket>();
        }

        public static MockDatabase Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MockDatabase();
                }
                return instance;
            }
        }

        public Product AddProduct(Product p)
        {
            p.Id = _products.Count + 1;
            _products.Add(p);

            return p;
        }

        public void DeleteProduct(int id)
        {
            _products.Where(x => x.Id == id).ToList().ForEach(i => i.Deleted = true);
        }

        public List<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProduct(int id)
        {
            // probably need to check deleted etc...
            Product prod = _products.Where(x => x.Id == id).FirstOrDefault();
            return prod;
        }

        public Basket CreateBasket(int userId)
        {
            Basket basket = new Basket();
            basket.UserId = userId;
            basket.Id = _baskets.Count + 1;
            _baskets.Add(basket.Id, basket);

            return basket;
        }

        public Basket GetBasket(int id)
        {
            Basket b = null;

            if (_baskets.ContainsKey(id))
            {
                b = _baskets[id];
                Product p;
                //populate the prodct details.
                foreach (BasketProduct bp in b.BasketProducts)
                {
                    p = _products.Where(x => x.Id == bp.Id).SingleOrDefault() as Product;
                    bp.Name = p.Name;
                    bp.Price = p.Price;
                }
            }

            return b;
        }

        public void ClearBasket(int id)
        {
            Basket b = null;

            if (_baskets.ContainsKey(id))
            {
                b = _baskets[id];
                b.BasketProducts.Clear();             
            }
        }

        public void DeleteBasket(int id)
        {
            if (_baskets.ContainsKey(id))
            {
                _baskets.Remove(id);
            }
        }

        public void UpdateBasket(Basket basket)
        {
            if (_baskets.ContainsKey(basket.Id))
            {
                _baskets[basket.Id]= basket;
            }
        }

        public void AddProductToBasket(int basketId, int productId)
        {
            UpdateProductInBasket(basketId,productId,1);
        }

        public void AddProductToBasket(int basketId, BasketProduct basketProduct)
        {
            UpdateProductInBasket(basketId, basketProduct.Id, basketProduct.Quantity);
        }

        public void RemoveProductFromBasket(int basketId, int productId)
        {
            if (_baskets.ContainsKey(basketId))
            {
                Basket basket = _baskets[basketId];
                BasketProduct basketProduct = basket.BasketProducts.Where(x => x.Id == productId).SingleOrDefault() as BasketProduct;
            
                if (basketProduct != null)
                    basket.BasketProducts.Remove(basketProduct);

            }
        }
        
        public void UpdateProductInBasket(int basketId, BasketProduct basketProduct)
        {
            UpdateProductInBasket(basketId, basketProduct.Id, basketProduct.Quantity);
        }
        /// <summary>
        /// update product in basket - add if new, update/repace if already exists
        /// </summary>
        /// <param name="basketId"></param>
        /// <param name="productId"></param>
        /// <param name="quantity"></param>
        private void UpdateProductInBasket(int basketId, int productId, int quantity)
        {
            if (_baskets.ContainsKey(basketId))
            {
                Basket basket = _baskets[basketId];
                BasketProduct basketProduct = basket.BasketProducts.Where(x => x.Id == productId).SingleOrDefault() as BasketProduct;
                Product p = _products.Where(x => x.Id == productId).SingleOrDefault() as Product;

                
                if (basketProduct != null)
                    basket.BasketProducts.Remove(basketProduct);

                basketProduct = new BasketProduct();
                
                basketProduct.Id = p.Id;
                basketProduct.Name = p.Name;
                basketProduct.Price = p.Price;
                basketProduct.Quantity = quantity;
                
                basket.BasketProducts.Add(basketProduct);                
            }

        }

    }
    
}
