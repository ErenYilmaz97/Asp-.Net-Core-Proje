using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspCoreProject.Entity
{
     public class Category:Entity
    {
        public Category()
        {
            Products = new List<Product>();
        }
        [Key] 
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products { get; set; }  //1 KATEGORİDE BİRSÜRÜ ÜRÜN
    }
}
