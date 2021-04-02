using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Assignment.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int QtyInStock { get; set; }
        public string Description { get; set; }
        public string Supplier { get; set; }

    }
}