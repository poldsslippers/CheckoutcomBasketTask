using BasketClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;


namespace BasketEndPointClassLibrary
{
    public class BasketEndPointsHandler
    {
        /// <summary>
        /// Basic wrapper around some of the api's exposed in the basket controller
        /// Not done any error trapping or exception handing as I'm not sure how you would prefer 
        /// to deal with it... 
        /// You can use this class to Create a basket, add products, remove products and clear the basket
        /// Need to sort out how to best to associate a basket with a user and general security
        /// </summary>

        private static string _baseUri = ""; 
        
        public BasketEndPointsHandler(string baseUri)
        {
            _baseUri = baseUri;
        }


        public Product GetProduct(int productId)
        {
            return GetProduct(_baseUri, productId);
        }

        public Product GetProduct(string baseUri, int productId)
        {
            Product product = new Product();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.GetAsync("api/product/"+ productId).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //product = await response.Content.ReadAsAsync<Product>();
                        product = response.Content.ReadAsAsync<Product>().Result;
                    }
                }
                catch
                {
                    //todo handle exception

                }
            }
            return product;
        }

        public Basket CreateBasket()
        {
            return CreateBasket(_baseUri);
        }
        public Basket CreateBasket(string baseUri)
        {
            Basket basket = new Basket();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.PostAsync("api/Basket/",null).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //product = await response.Content.ReadAsAsync<Product>();
                        basket = response.Content.ReadAsAsync<Basket>().Result;
                    }
                }
                catch
                {
                    //todo handle exception

                }
            }
            return basket;
        }

        public Basket GetBasket(int basketId)
        {
            return GetBasket(_baseUri, basketId);
        }
        public Basket GetBasket(string baseUri, int basketId)
        {
            Basket basket = new Basket();
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.GetAsync("api/Basket/"+basketId).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //product = await response.Content.ReadAsAsync<Product>();
                        basket = response.Content.ReadAsAsync<Basket>().Result;
                    }
                }
                catch
                {
                    //todo handle exception

                }
            }
            return basket;
        }

        public void RemoveProductFromBasket(int basketId, int productId)
        {
            RemoveProductFromBasket(_baseUri, basketId, productId);
        }
        public void RemoveProductFromBasket(string baseUri, int basketId, int productID)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.DeleteAsync("api/Basket/" + basketId+"/"+ productID).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //todo do we need a response
                    }
                    else
                    {
                        //dodo return failed message?
                    }
                }
                catch
                {
                    //todo handle exception

                }
            }
        }



        public void ClearBasket(Basket basket)
        {
            ClearBasket(_baseUri, basket);
        }
        public void ClearBasket(string baseUri, Basket basket )
        {
            //api / Basket / ClearBasket /
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.PutAsync("api/Basket/ClearBasket/"+ basket.Id, null).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //todo do we need a response
                    } 
                    else
                    {
                        //dodo return failed message?
                    }
                }
                catch
                {
                    //todo handle exception

                }
            }
        }

        public void AddProductToBasket(int productId, int basketId)
        {
            AddProductToBasket(_baseUri, productId, basketId);
        }

        public void AddProductToBasket(string baseUri,int productId, int basketId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseUri);

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = client.PutAsync("api/Basket/"+basketId+"/" + productId, null).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        //todo do we need a response
                    }
                    else
                    {
                        //dodo return failed message?
                    }
                }
                catch
                {
                    //todo handle exception

                }
            }
        }

        
    }
}