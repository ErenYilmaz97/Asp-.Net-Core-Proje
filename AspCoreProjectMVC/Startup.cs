using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.DataAccess;
using AspCoreProject.DataAccess.Abstract;
using AspCoreProject.Entity.DbContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using EnvironmentName = Microsoft.AspNetCore.Hosting.EnvironmentName;

namespace AspCoreProjectMVC
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(x => x.EnableEndpointRouting = false);
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnectionString")));
            //CONTEXT INJECTION

            services.AddScoped<IProductServices, ProductDal>();    //IPRODUCTSERVÝCE ÝSTENDÝÐÝNDE, PRODUCTDAL VER.
            services.AddTransient<ICategoryServices, CategoryDal>();
            services.AddTransient<ICompanyServices, CompanyDal>();
            services.AddScoped<ICustomerServices, CustomerDal>();
            services.AddScoped<IEmployeeServices,EmployeeDal>();
            
        }

       
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            env.EnvironmentName = EnvironmentName.Development;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseMvc(configureRoutes);
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default", "{Controller=Customer}/{Action=Index}/{id?}");
        }
    }
}
