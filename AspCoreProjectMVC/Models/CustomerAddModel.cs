using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.Entity;

namespace AspCoreProjectMVC.Models
{
    public class CustomerAddModel
    {
        

        [Required(ErrorMessage = "Lütfen İsim Alanını Doldurunuz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Soyisim Alanını Doldurunuz")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Lütfen Şehir Alanını Doldurunuz")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen Ülke Alanını Doldurunuz")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Lütfen Adres Alanını Doldurunuz")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Lütfen Telefon Alanını Doldurunuz")]
        [Phone]
        public string Phone { get; set; }
    }
}
