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
    public class EmployeeController : Controller
    {
        private  IEmployeeServices IEmployeeServices;

        public EmployeeController(IEmployeeServices _IEmployeeServices)
        {
            IEmployeeServices = _IEmployeeServices;
        }

        

        [HttpGet]
        [Route("~/Employee/Index")]
        [Route("~/Employee")]
        public IActionResult Index()
        {
            EmployeeListModel employeeListModel = new EmployeeListModel
            {
                EmployeeLists = IEmployeeServices.EmployeeList().ToList()
            };
            return View(employeeListModel);
        }


        [HttpGet]
        [Route("~/Employee/Delete/{id:int?}")]
        public IActionResult Delete(int id)
        {
            IEmployeeServices.Delete(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("~/Employee/Add")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(EmployeeAddModel employeeAddModel)
        {
            if (!ModelState.IsValid)    //VALİDASYON UYMUYORSA EKRANA GERİ DÖN.
            {
                return View(employeeAddModel);
            }

            else    //UYUYORSA, GELEN BİLGİLERLE NESNE OLUŞTUR VE DATAACCESS'E YOLLA.
            {
                Employee employee = new Employee
                {
                    FirstName = employeeAddModel.Name,
                    LastName = employeeAddModel.Lastname,
                    City = employeeAddModel.City,
                    Country = employeeAddModel.Country,
                    Adress = employeeAddModel.Adress,
                    HomePhone = employeeAddModel.Phone
                };

                IEmployeeServices.Add(employee);
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        [Route("~/Employee/Update/{id:int?}")]
        public IActionResult Update(int id)
        {
            Employee getEmployee = IEmployeeServices.GetEmployee(id);
            EmployeeAddModel employeeAddModel = new EmployeeAddModel
            {
                ID = id,
                Name = getEmployee.FirstName,
                Lastname = getEmployee.LastName,
                City = getEmployee.City,
                Country = getEmployee.Country,
                Adress = getEmployee.Adress,
                Phone = getEmployee.HomePhone
            };

            return View(employeeAddModel);
        }

        [HttpPost]
        public IActionResult Update(EmployeeAddModel employeeAddModel)
        {
            if (!ModelState.IsValid)
            {
                return View(employeeAddModel);
            }

            else
            {
                Employee employee = new Employee
                {
                    EmployeeID = employeeAddModel.ID,
                    FirstName = employeeAddModel.Name,
                    LastName = employeeAddModel.Lastname,
                    City = employeeAddModel.City,
                    Country = employeeAddModel.Country,
                    Adress = employeeAddModel.Adress,
                    HomePhone = employeeAddModel.Phone
                };

                IEmployeeServices.Update(employee);
                return RedirectToAction("Index");
            }
        }
    }
}
