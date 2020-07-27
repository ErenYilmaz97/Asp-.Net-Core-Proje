using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AspCoreProject.Entity
{
    public class Order:Entity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetail>();
        }
        [Key] 
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAdress { get; set; }

        public Customer Customer { get; set; }  //1 SİPARİŞ 1 MÜŞTERİYE AİT
        public Employee Employee { get; set; }  //1 SİPARİŞ 1 PERSONELE AİT
        public List<OrderDetail> OrderDetails { get; set; }    //1 ÜRÜNÜN BİR ÇOK DETAYI
    }
}
