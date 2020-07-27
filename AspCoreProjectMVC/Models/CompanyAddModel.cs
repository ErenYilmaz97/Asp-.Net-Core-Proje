using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreProjectMVC.Models
{
    public class CompanyAddModel
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Lütfen Firma Adını Giriniz.")]
        public string CompanyName { get; set; }
    }
}
