using RetaileAPILibrary.DataAccess;
using RetaileAPILibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace RetaileAPI.Controllers
{
    [Authorize]
    public class ProductController : ApiController
    {
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();
            return data.GetProducts();
        }
    }
}
