using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreProjectMVC.Controllers
{
    [Controller]
    public class CategoryController : Controller
    {
        private ICategoryServices ICategoryServices;

        public CategoryController(ICategoryServices _ICategoryServices)
        {
            ICategoryServices = _ICategoryServices;
        }

        [HttpGet]
        [Route("~/Category")]
        [Route("~/Category/Index")]
        public IActionResult Index()
        {
            CategoryListModel listModel = new CategoryListModel
            {
                categoryList = ICategoryServices.CategoryList().ToList()
            };

            return View(listModel);
        }

        [HttpGet]
        [Route("~/Category/Delete/{id:int?}")]
        public IActionResult Delete(int id)
        {
            ICategoryServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("~/Category/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryAddModel categoryAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryAddModel);
            }

            else
            {
                Category category = new Category
                {
                    CategoryName = categoryAddModel.CategoryName
                };

                ICategoryServices.Add(category);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("~/Category/Update/{id:int?}")]
        public IActionResult Update(int id)
        {
            Category getCategory = ICategoryServices.GetCategory(id);
            CategoryAddModel categoryAddModel = new CategoryAddModel
            {
                ID = getCategory.CategoryID,
                CategoryName = getCategory.CategoryName
            };

            return View(categoryAddModel);
        }

        [HttpPost]
        public IActionResult Update(CategoryAddModel categoryAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(categoryAddModel);
            }

            else
            {
                Category category = new Category
                {
                    CategoryID = categoryAddModel.ID,
                    CategoryName = categoryAddModel.CategoryName
                };

                ICategoryServices.Update(category);
                return RedirectToAction("Index");
            }
        }


    }
}
