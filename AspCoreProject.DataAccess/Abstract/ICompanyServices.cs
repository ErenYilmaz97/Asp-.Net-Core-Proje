using System;
using System.Collections.Generic;
using System.Text;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;

namespace AspCoreProject.DataAccess.Abstract
{
    public interface ICompanyServices
    {
        List<CompanyList> CompanyList();
        Company GetCompany(int id);
        void Add(Company company);
        void Delete(int id);
        void Update(Company company);
        List<CompanyListItem> CompanyListItem();

    }
}
