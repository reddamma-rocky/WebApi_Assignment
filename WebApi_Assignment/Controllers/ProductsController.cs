using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi_Assignment.Models;

namespace WebApi_Assignment.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> _productList = null;
        void Initialize()
        {
            _productList = new List<Product>()
           {
               new Product() { ProductId=1, Name="salt" , QtyInStock=10, Description="salt is used for cooking", Supplier="reddy"},

               new Product() { ProductId=2, Name="oil" , QtyInStock=20, Description="oil is used for cooking", Supplier="bittu"},
           };

        }
        public ProductsController()
        {
            if (_productList == null)
            {
                Initialize();
            }
        }

        // GET: api/Students
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, _productList);
        }

        // GET: api/Students/5
        public HttpResponseMessage Get(int id)
        {
            Product product = _productList.FirstOrDefault(x => x.ProductId == id);
            if (product == null)
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");
            else
                return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        // POST: api/Students
        public HttpResponseMessage Post(Product product)
        {
            if (product != null)
            {
                _productList.Add(product);
            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // PUT: api/Students/5
        public HttpResponseMessage Put(int id, Product objStudent)
        {
            Product product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");

            }
            else
            {
                if (product != null)
                {
                    foreach (Product temp in _productList)
                    {
                        if (temp.ProductId == id)
                        {
                            temp.Name = objStudent.Name;
                            temp.QtyInStock = objStudent.QtyInStock;
                            temp.Description = objStudent.Description;
                            temp.Supplier = objStudent.Supplier;
                        }
                    }


                }
                return Request.CreateResponse(HttpStatusCode.OK, "Modified");

            }
        }

        // DELETE: api/Students/5
        public HttpResponseMessage Delete(int id)
        {
            Product product = _productList.Where(x => x.ProductId == id).FirstOrDefault();
            if (product == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product Not found");

            }
            else
            {
                if (product != null)
                {
                    _productList.Remove(product);
                }
                return Request.CreateResponse(HttpStatusCode.OK, "Deleteed");
            }

        }
    }
}