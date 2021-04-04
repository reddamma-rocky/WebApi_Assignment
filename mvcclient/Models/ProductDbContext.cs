using mvcclient;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcEFHttpClient.Models
{
    public class ProductDBContext : DbContext
    {
        public DbSet<Product> products { get; set; }
    }
}

