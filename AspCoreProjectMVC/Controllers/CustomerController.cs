using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.DataAccess;
using AspCoreProject.Entity;
using AspCoreProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreProjectMVC.Controllers
{
    [Controller]
    public class CustomerController : Controller
    {
        private  ICustomerServices ICustomerService;

        public CustomerController(ICustomerServices _ICustomerService)
        {
            ICustomerService = _ICustomerService;
        }



        [HttpGet]
        [Route("")]
        [Route("~/Customer")]
        [Route("~/Customer/Index")]
        public IActionResult Index()
        {
            CustomerListModel customerModel = new CustomerListModel
            {
                CustomerList = ICustomerService.CustomerList().ToList()
            };
            return View(customerModel);  //GELEN LİSTEYİ MODELE ATIP VİEW'A YOLLA
        }

        [HttpGet]
        [Route("~/Customer/Delete/{id:int?}")]
        public IActionResult Delete(int id)
        {
            ICustomerService.Delete(id);  //IDSİ GELEN KAYITI SİL
            return RedirectToAction("Index");

        }

        [HttpGet]
        [Route("~/Customer/Update/{id:int?}")]
        public IActionResult Update(int id)
        {
            Customer getCustomer = ICustomerService.GetCustomer(id);
            CustomerUpdateModel customerUpdateModel = new CustomerUpdateModel
            {
                ID = id,
                Name = getCustomer.CustomerName,
                Lastname = getCustomer.CustomerLastname,
                City = getCustomer.City,
                Country = getCustomer.Country,
                Adress = getCustomer.Adress,
                Phone = getCustomer.Phone
            };
            return View(customerUpdateModel);   //BU BİLGİLERİ ALANLARA YAZMAK İÇİN VİEW'A YOLLA
        }

        [HttpPost]
        public IActionResult Update(CustomerUpdateModel customerUpdateModel)
        {
            if (!ModelState.IsValid)
            {
                return View(customerUpdateModel); //MODELDEKİ VALİDASYONA UYMUYORSA VİEW'I GERİ DÖNDÜR.
            }

            
            else
            {
                Customer customer = new Customer //GELEN MODEL İLE BİR CUSTOMER OLUŞTUR
                {
                    CustomerID = customerUpdateModel.ID,
                    CustomerName = customerUpdateModel.Name,
                    CustomerLastname = customerUpdateModel.Lastname,
                    City = customerUpdateModel.City,
                    Country = customerUpdateModel.Country,
                    Adress = customerUpdateModel.Adress,
                    Phone = customerUpdateModel.Phone
                };

                ICustomerService.Update(customer); //BUNU UPDATE METHOTUNA YOLLA.
                return RedirectToAction("Index"); //SAYFAYI YENİLE
            }
        }
    

        [HttpGet]
         [Route("~/Customer/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CustomerAddModel customerAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(customerAddModel);
            }

            else
            {
                Customer customer = new Customer   //GELEN MODEL İLE NESNE OLUŞTUR
                {
                    CustomerName = customerAddModel.Name,
                    CustomerLastname = customerAddModel.Lastname,
                    City = customerAddModel.City,
                    Country = customerAddModel.Country,
                    Adress = customerAddModel.Adress,
                    Phone = customerAddModel.Phone
                };

                ICustomerService.Add(customer);     //VERİTABANINA EKLE
                return RedirectToAction("Index");   //SAYFAYIYENİLE
            }
        }

        
    }
}
