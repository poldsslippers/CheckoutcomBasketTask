using BasketClassLibrary;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CheckoutBasketTask.Controllers
{
    public class BasketController : ApiController
    {
        /// <summary>
        /// Basic controller with some functionality. 
        /// Should move the data access into its own layer which will help exception handling and responses
        /// MockDatabase is simple class pretending to do basic database features
        /// 
        /// Wasn't sure what the security requirements would be, if any....
        /// Or if you wanted to persis the basket in a database or on the client - although without a database this doesn't really care!
        /// 
        /// I've not done any unit tests but I did create a console up to test 
        ///    Creating a basket, adding/removing products and clearing the product list. 
        /// 
        /// </summary>
        /// <returns></returns>


        // POST api/values
        public IHttpActionResult Post()
        {
            // Not added any authentication for now but basket will need to be contain an owner
            // mock this for now.             
            // var v = RequestContext.Principal.Identity;

            Basket basket = MockDatabase.Instance.CreateBasket(234);
            
            if (basket == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Couldn't create Basket"));                
            }

            return Ok(basket);
        }

        public IHttpActionResult Get(int id)
        {
            Basket basket = MockDatabase.Instance.GetBasket(id);
            if (basket == null)
            {
                return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.NotFound, "Couldn't find Basket " +id));
                //return NotFound();
            }
            return Ok(basket);
        }

        [Route("api/Basket/ClearBasket/{basketId}")]
        [HttpPut]
        public IHttpActionResult ClearBasket(int basketId)
        {
            MockDatabase.Instance.ClearBasket(basketId);

            return Ok();
        }
        
        [HttpPut]
        public IHttpActionResult UpdateBasket([FromBody] Basket basket)
        {
            MockDatabase.Instance.UpdateBasket(basket);
            return Ok();
        }


        [Route("api/Basket/{basketId}/{productId}")]
        public IHttpActionResult Put(int basketId, int productId)
        {
            MockDatabase.Instance.AddProductToBasket(basketId, productId);

            return Ok();
        }

        [Route("api/Basket/{basketId}/{productId}")]
        public IHttpActionResult Delete(int basketId, int productId)
        {
            MockDatabase.Instance.RemoveProductFromBasket(basketId, productId);

            return Ok();
        }


    }
}
