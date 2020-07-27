using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspCoreProject.Entity
{
    public class Company:Entity
    {
        public Company()
        {
            Products = new List<Product>();
        }
        [Key] 
        public int CompanyID { get; set; }
        public string CompanyName { get; set; }

        public List<Product> Products { get; set; }  //1 FİRMANIN BİR ÇOK ÜRÜNÜ
    }
}
