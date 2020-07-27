using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace AspCoreProject.Entity
{
    public class Employee:Entity
    {
        public Employee()
        {
            Orders = new List<Order>();
        }
        [Key] 
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }

        public List<Order> Orders { get; set; }   //1 PERSONELİN BİR ÇOK SİPARİŞİ

    }
}
