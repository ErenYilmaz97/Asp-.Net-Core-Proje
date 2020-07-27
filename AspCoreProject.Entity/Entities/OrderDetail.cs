using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspCoreProject.Entity
{
    public class OrderDetail:Entity
    {
        [Key] 
        public int DetailID { get; set; }
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }


        public Order Order { get; set; }       //1 DETAY 1 SİPARİŞE AİT
        public Product Product { get; set; }   //1 DETAY 1 ÜRÜNE AİT
    }
}
