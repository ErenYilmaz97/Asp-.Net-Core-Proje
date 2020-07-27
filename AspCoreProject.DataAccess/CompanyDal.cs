using AspCoreProject.Entity.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity;
using AspCoreProject.Entity.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Identity;

namespace AspCoreProject.DataAccess
{
    
    public class CompanyDal:ICompanyServices
    {
        private readonly AppDbContext _context;

        public CompanyDal(AppDbContext context)
        {
            _context = context;
        }

        public List<CompanyList> CompanyList()
        {
            var result = (from item in _context.Companies
                select new CompanyList
                {
                    CompanyID = item.CompanyID,
                    Company = item.CompanyName,
                }).ToList();

            return result;

        }


        public Company GetCompany(int id)
        {
            return _context.Companies.Find(id);
        }

        public void Add(Company company)
        {
           Company findCompany = _context.Companies.Where(x=>x.CompanyName.ToLower() == company.CompanyName.ToLower()).FirstOrDefault();

           if (findCompany != null)
           {
               throw new ApplicationException();
           }
           else
           {
               var addCompany = _context.Entry(company);
               addCompany.State = EntityState.Added;
               _context.SaveChanges();

           }
        }

        public void Delete(int id)
        {
            Company findCompany = _context.Companies.Find(id);

            if (findCompany == null)
            {
                throw new ApplicationException();
            }

            else
            {
                var deleteCompany = _context.Entry(findCompany);
                deleteCompany.State = EntityState.Deleted;
                _context.SaveChanges();
            }
        }

        public void Update(Company company)
        {
            var updateCompany = _context.Entry(company);
            updateCompany.State = EntityState.Modified;
            _context.SaveChanges();

        }

        public List<CompanyListItem> CompanyListItem()
        {
            var result = (from item in _context.Companies
                select new CompanyListItem
                {
                    ID = item.CompanyID,
                    CompanyName = item.CompanyName

                }).ToList();

            return result;


        }
    }
}
