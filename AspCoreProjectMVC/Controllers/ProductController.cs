using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.DataAccess;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;
using AspCoreProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspCoreProjectMVC.Controllers
{
    [Controller]
    public class ProductController : Controller
    {
        private  IProductServices IProductService;
        private  ICategoryServices ICategoryServices;
        private  ICompanyServices ICompanyServices;

        public ProductController(IProductServices _IProductService, ICategoryServices _ICategoryServices, ICompanyServices _ICompanyServices)
        {
            IProductService = _IProductService;
            ICategoryServices = _ICategoryServices;
            ICompanyServices = _ICompanyServices;
        }


        [HttpGet]
        
        public IActionResult Index()
        {
            ProductListModel productListModel = new ProductListModel
            {
                ProductList = IProductService.ProductList().ToList()
            };
            return View(productListModel);
        }

        [HttpGet]
        [Route("~/Product/Add")]
        public IActionResult Add()
        {
            //LİSTELERİ OLUŞTUR, FOREACH İLE İÇLERİNİ DOLDUR
            List<SelectListItem> SelectCategory = new List<SelectListItem>{new SelectListItem(text : "Kategori Seçiniz", value : "")};
            List<SelectListItem> SelectCompany = new List<SelectListItem> { new SelectListItem(text: "Firma Seçiniz", value: "")};

            foreach (var item in ICategoryServices.CategoryListItem())
            {
                SelectCategory.Add(new SelectListItem{Text = item.CategoryName, Value = item.ID.ToString()});
            }


            foreach (var item2 in ICompanyServices.CompanyListItem())
            {
                SelectCompany.Add(new SelectListItem { Text = item2.CompanyName, Value = item2.ID.ToString()});
            }

            //LİSTELER TAMAM, MODELİ OLUŞTURUP İLGİLİ ALANLARA SETLE VİEW'A YOLLA

            ProductAddModel productAddModel = new ProductAddModel
            {
                CategorySelectList = SelectCategory,
                CompanySelecList = SelectCompany
            };
            
            return View(productAddModel);
        }

        [HttpPost]
        public IActionResult Add(ProductAddModel productAddModel)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> SelectCategory = new List<SelectListItem> { new SelectListItem(text: "Kategori Seçiniz", value: "") };
                List<SelectListItem> SelectCompany = new List<SelectListItem> { new SelectListItem(text: "Firma Seçiniz", value: "") };
                foreach (var item in ICategoryServices.CategoryListItem())
                {
                    SelectCategory.Add(new SelectListItem { Text = item.CategoryName, Value = item.ID.ToString() });
                }


                foreach (var item2 in ICompanyServices.CompanyListItem())
                {
                    SelectCompany.Add(new SelectListItem { Text = item2.CompanyName, Value = item2.ID.ToString() });
                }

                productAddModel.CategorySelectList = SelectCategory;
                productAddModel.CompanySelecList = SelectCompany;

                return View(productAddModel);
            }

            else
            {
                Product product = new Product
                {
                    ProductName = productAddModel.Product,
                    CategoryID = productAddModel.CategoryID,
                    CompanyID = productAddModel.CompanyID,
                    Price = productAddModel.Price,
                    QuantityPerUnit = productAddModel.QuantityPerUnit
                };

                IProductService.Add(product);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Route("~/Product/Delete/{id:int?}")]
        public IActionResult Delete(int id)
        {
            IProductService.Delete(id);
            return RedirectToAction("Index");
        }




        [HttpGet]
        [Route("~/Product/Update/{id:int?}")]
        public IActionResult Update(int id)
        {
            Product getProduct = IProductService.GetProduct(id);

            //LİSTELERİ OLUŞTUR
            List<SelectListItem> SelectCategory = new List<SelectListItem> { new SelectListItem { Text = "Kategori", Value = "" } };
            List<SelectListItem> SelectCompany = new List<SelectListItem> { new SelectListItem { Text = "Firma", Value = "" } };

            foreach (var category in ICategoryServices.CategoryListItem())
            {
                SelectCategory.Add(new SelectListItem { Text = category.CategoryName, Value = category.ID.ToString() });
            }

            foreach (var company in ICompanyServices.CompanyListItem())
            {
                SelectCompany.Add(new SelectListItem { Text = company.CompanyName, Value = company.ID.ToString() });
            }


            ProductAddModel productAddModel = new ProductAddModel
            {
                ID = id,
                Product = getProduct.ProductName,
                CategoryID = getProduct.CategoryID,
                CompanyID = getProduct.CompanyID,
                Price = getProduct.Price,
                QuantityPerUnit = getProduct.QuantityPerUnit,
                CategorySelectList = SelectCategory,
                CompanySelecList = SelectCompany

            };
            return View(productAddModel);   //BU BİLGİLERİ ALANLARA YAZMAK İÇİN VİEW'A YOLLA
        }

        [HttpPost]
        public IActionResult Update(ProductAddModel productAddModel)
        {
            if (!ModelState.IsValid)
            {
                List<SelectListItem> SelectCategory = new List<SelectListItem> { new SelectListItem { Text = "Kategori", Value = "" } };
                List<SelectListItem> SelectCompany = new List<SelectListItem> { new SelectListItem { Text = "Firma", Value = "" } };

                foreach (var category in ICategoryServices.CategoryListItem())
                {
                    SelectCategory.Add(new SelectListItem { Text = category.CategoryName, Value = category.ID.ToString() });
                }

                foreach (var company in ICompanyServices.CompanyListItem())
                {
                    SelectCompany.Add(new SelectListItem { Text = company.CompanyName, Value = company.ID.ToString() });
                }

                productAddModel.CategorySelectList = SelectCategory;
                productAddModel.CompanySelecList = SelectCompany;
                return View(productAddModel);   //MODELDEKİ VALİDASYONA UYMUYORSA VİEW'I GERİ DÖNDÜR.
            }

            else
            {
                Product product = new Product   //GELEN MODEL İLE BİR CUSTOMER OLUŞTUR
                {
                    ProductID = productAddModel.ID,
                    ProductName = productAddModel.Product,
                    CategoryID = productAddModel.CategoryID,
                    CompanyID = productAddModel.CompanyID,
                    Price = productAddModel.Price,
                    QuantityPerUnit = productAddModel.QuantityPerUnit
                };

                IProductService.Update(product);  //BUNU UPDATE METHOTUNA YOLLA.
                return RedirectToAction("Index");   //SAYFAYI YENİLE
            }
        }
    }
    }

