using System.Collections.Generic;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;

namespace AspCoreProject.DataAccess
{
    public interface ICustomerServices
    {
        List<CustomerList> CustomerList();
        Customer GetCustomer(int id);
        void Add(Customer customer);
        void Delete(int id);
        void Update(Customer customer);
    }
}