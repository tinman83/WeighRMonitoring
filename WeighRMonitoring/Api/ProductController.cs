using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WeighRMonitoring.Models.Components;
using WeighRMonitoring.Models.Entities;

namespace WeighRMonitoring.Api
{
    public class ProductController : ApiController
    {
        // GET: api/Dashboard
        public List<Product> GetProducts()
        {
            ProductComponent productComp = new ProductComponent();

            return productComp.GetProducts();
        }

    }
}
