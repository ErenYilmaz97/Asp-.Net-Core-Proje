using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.Entity;

namespace AspCoreProjectMVC.Models
{
    public class CategoryAddModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen Kategori İsmi Giriniz.")]
        public string CategoryName { get; set; }
    }
}
