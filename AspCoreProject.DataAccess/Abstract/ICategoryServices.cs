using System;
using System.Collections.Generic;
using System.Text;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;

namespace AspCoreProject.DataAccess.Abstract
{
    public interface ICategoryServices
    {
        List<CategoryList> CategoryList();
        Category GetCategory(int id);
        void Add(Category category);
        void Delete(int id);
        void Update(Category category);
        List<CategoryListItem> CategoryListItem();


    }
}
