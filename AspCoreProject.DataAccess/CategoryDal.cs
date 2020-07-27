using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProject.Entity.DbContext;
using AspCoreProject.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

namespace AspCoreProject.DataAccess
{
    public class CategoryDal:ICategoryServices
    {
        private readonly AppDbContext _context;

        public CategoryDal(AppDbContext context)
        {
            _context = context;
        }

        public List<CategoryList> CategoryList()
        {
            var result = (from item in _context.Categories
                select new CategoryList
                        {
                            CategoryID = item.CategoryID,
                            Category = item.CategoryName,
                            

                        }).ToList();

            return result;
        }


        public Category GetCategory(int id)
        {
            return _context.Categories.Find(id);
        }

        public void Add(Category category)
        {
            Category FindCategory = _context.Categories.Where(x=>x.CategoryName.ToLower() == category.CategoryName.ToLower()).FirstOrDefault();

            if (FindCategory != null)
            {
                throw new ApplicationException();
            }
            else
            {
                var addCategory = _context.Entry(category);
                addCategory.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            Category findCategory = _context.Categories.Find(id);

            if (findCategory == null)
            {
                throw new ApplicationException();
            }
            else
            {
                var addCategory = _context.Entry(findCategory);
                addCategory.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(Category category)
        {
            var updateCustomer = _context.Entry(category);
            updateCustomer.State = EntityState.Modified;
            _context.SaveChanges();

        }

        public List<CategoryListItem> CategoryListItem()
        {
            var result = (from item in _context.Categories
                select new CategoryListItem
                {
                    ID = item.CategoryID,
                    CategoryName = item.CategoryName
                }).ToList();

            return result;
        } 
    }
}
