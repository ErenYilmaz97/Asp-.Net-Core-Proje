using System;
using System.Collections.Generic;
using System.Text;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;

namespace AspCoreProject.DataAccess.Abstract
{
    public interface IEmployeeServices
    {
        List<EmployeeList> EmployeeList();
        Employee GetEmployee(int id);
        void Add(Employee employee);
        void Delete(int id);
        void Update(Employee employee);
    }
}
