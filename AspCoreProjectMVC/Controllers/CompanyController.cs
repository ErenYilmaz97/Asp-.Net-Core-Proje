using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;
using AspCoreProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreProjectMVC.Controllers
{
    [Controller]
    public class CompanyController : Controller
    {
        private ICompanyServices ICompanyServices;

        public CompanyController(ICompanyServices _ICompanyServices)
        {
            ICompanyServices = _ICompanyServices;
        }

        [HttpGet]
        [Route("~/Company")]
        [Route("~/Company/Index")]
        public IActionResult Index()
        {
            CompanyListModel companyListModel = new CompanyListModel
            {
                CompanyList = ICompanyServices.CompanyList().ToList()
            };
            return View(companyListModel);
        }


        [HttpGet]
        [Route("~/Company/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CompanyAddModel companyAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(companyAddModel);
            }

            else
            {
                Company company = new Company
                {
                    CompanyName = companyAddModel.CompanyName
                };

                ICompanyServices.Add(company);
                return RedirectToAction("Index","Company");
            }

        }

        [HttpGet]
        [Route("~/Company/Delete/{id:int?}")]
        public IActionResult Delete(int id)
        {
           ICompanyServices.Delete(id);
           return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("~/Company/Update/{id:int?}")]
        public IActionResult Update(int id)
        {
            Company getCompany = ICompanyServices.GetCompany(id);

            CompanyAddModel companyAddModel = new CompanyAddModel
            {
                ID = getCompany.CompanyID,
                CompanyName = getCompany.CompanyName
            };

            return View(companyAddModel);
        }

        [HttpPost]
        public IActionResult Update(CompanyAddModel companyAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(companyAddModel);
            }

            else
            {
                Company company = new Company
                {
                    CompanyID = companyAddModel.ID,
                    CompanyName = companyAddModel.CompanyName
                };

                ICompanyServices.Update(company);
                return RedirectToAction("Index");
            }
        }

    }
}
