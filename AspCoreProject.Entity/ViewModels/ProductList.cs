using System;
using System.Collections.Generic;
using System.Text;

namespace AspCoreProject.Entity.ViewModels
{
    public class ProductList
    {
        public int ID { get; set; }
        public string Product { get; set; }
        public string Category { get; set; }
        public string Company { get; set; }
        public decimal Price { get; set; }
        public string QuantityPerUnit { get; set; }
    }
}
