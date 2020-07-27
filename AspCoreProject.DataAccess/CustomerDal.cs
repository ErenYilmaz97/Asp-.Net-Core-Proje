using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspCoreProject.Entity;
using AspCoreProject.Entity.DbContext;
using AspCoreProject.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspCoreProject.DataAccess
{
    public class CustomerDal:ICustomerServices
    {
        private readonly AppDbContext _context;

        public CustomerDal(AppDbContext context)
        {
            _context = context;
        }

        public List<CustomerList> CustomerList()
        {
            var result = (from item in _context.Customers
                select new CustomerList
                {
                    ID = item.CustomerID,
                    Name = item.CustomerName,
                    Lastname = item.CustomerLastname,
                    City = item.City,
                    Country = item.Country,
                    Adress = item.Adress,
                    Phone = item.Phone
                }).ToList();

            return result;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.Find(id);
        }

        public void Add(Customer customer)
        {
            Customer findCustomer = _context.Customers.Where(x => x.CustomerName.ToLower() == customer.CustomerName.ToLower()).FirstOrDefault();
            if (findCustomer != null)
            {
                throw new ApplicationException();
            }
            else
            {
                var addCustomer = _context.Entry(customer);
                addCustomer.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Customer findcustomer = _context.Customers.Find(id);
            if (findcustomer == null)
            {
                throw new ApplicationException();
            }
            else
            {
                var deleteCustomer = _context.Entry(findcustomer);
                deleteCustomer.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(Customer customer)
        {
            
                var updateCustomer = _context.Entry(customer);
                updateCustomer.State = EntityState.Modified;
                _context.SaveChanges();
            


        }
    }
}
