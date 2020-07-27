using System;
using System.Collections.Generic;
using System.Text;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;

namespace AspCoreProject.DataAccess.Abstract
{
    public interface IProductServices
    {
         List<ProductList> ProductList();
         Product GetProduct(int id);
         void Add(Product product);
         void Delete(int id);
         void Update(Product product);
    }
}
