using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspCoreProject.Entity
{
    public class Product:Entity
    {
        public Product()
        {
            OrderDetails = new List<OrderDetail>();
        }
        [Key]
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public int CompanyID { get; set; }
        public string QuantityPerUnit { get; set; }

        public Category Category { get; set; }  //1 ÜRÜN 1 KATEGORİDE
        public Company Company { get; set; }    //1 ÜRÜN 1 FİRMAYA AİT
        public List<OrderDetail> OrderDetails { get; set; }  //1 ÜRÜNÜN BİR ÇOK DETAYI

    }
}
