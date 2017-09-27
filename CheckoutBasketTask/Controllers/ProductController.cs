using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BasketClassLibrary;

namespace CheckoutBasketTask.Controllers
{
    public class ProductController : ApiController
    {
        // GET api/values
        public IHttpActionResult Get()
        {
            
            List<Product> list = MockDatabase.Instance.GetProducts();
            return Ok(list);
        }

        // GET api/values/1
        public IHttpActionResult Get(int id)
        {
            Product prod = MockDatabase.Instance.GetProduct(id);
            if (prod == null)
                return NotFound();

            return Ok(prod);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            MockDatabase.Instance.DeleteProduct(id);
        }
    }
}
