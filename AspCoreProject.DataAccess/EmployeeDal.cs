using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProject.Entity.DbContext;
using AspCoreProject.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace AspCoreProject.DataAccess
{
    public class EmployeeDal:IEmployeeServices
    {
        private readonly AppDbContext _context;

        public EmployeeDal(AppDbContext context)
        {
            _context = context;
        }

        public List<EmployeeList> EmployeeList()
        {
            var result = (from item in _context.Employees
                select new EmployeeList
                {
                    EmployeeID = item.EmployeeID,
                    Name = item.FirstName,
                    LastName = item.LastName,
                    City = item.City,
                    Country = item.Country,
                    Adress = item.Adress,
                    Phone = item.HomePhone

                }).ToList();

            return result;
        }


        public Employee GetEmployee(int id)
        {
            return _context.Employees.Find(id);
        }

        public void Add(Employee employee)
        {
            Employee findEmployee = _context.Employees.Where(x=>x.FirstName.ToLower() == employee.FirstName.ToLower()).FirstOrDefault();

            if (findEmployee != null)
            {
                throw new ApplicationException();
            }

            else
            {
                var addEmployee = _context.Entry(employee);
                addEmployee.State = EntityState.Added;
                _context.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            var findEmployee = _context.Employees.Find(id);

            if (findEmployee == null)
            {
                throw new ApplicationException();
            }
            else
            {
                var deleteEmployee = _context.Entry(findEmployee);
                deleteEmployee.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(Employee employee)
        {
            var updateEmployee = _context.Entry(employee);
            updateEmployee.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
