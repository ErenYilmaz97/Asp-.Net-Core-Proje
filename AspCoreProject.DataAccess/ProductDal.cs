using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProject.Entity.DbContext;
using AspCoreProject.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

namespace AspCoreProject.DataAccess
{

    public class ProductDal:IProductServices
    {
        private readonly AppDbContext _context;

        public ProductDal(AppDbContext context)
        {
            _context = context;  //INJECTION YAPTIK
        }

        public List<ProductList> ProductList()   //LİSTELE
        {
            var result = (from item in _context.Products
                          join item2 in _context.Categories on item.CategoryID equals item2.CategoryID
                          join item3 in _context.Companies on item.CompanyID equals item3.CompanyID
                          select new ProductList
                          {
                            ID = item.ProductID,
                            Product = item.ProductName,
                            Category = item2.CategoryName,
                            Company = item3.CompanyName,
                            Price = item.Price,
                            QuantityPerUnit = item.QuantityPerUnit
                          }).ToList();

            return result;
        }


        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }

        public void Add(Product product)
        {
            
                var addProduct = _context.Entry(product);
                addProduct.State = EntityState.Added;
                _context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            var findProduct = _context.Products.Find(id);

            if (findProduct == null)
            {
                throw new ApplicationException();
            }
            else
            {
                var deleteProduct = _context.Entry(findProduct);
                deleteProduct.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            var updateProduct = _context.Entry(product);
            updateProduct.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
