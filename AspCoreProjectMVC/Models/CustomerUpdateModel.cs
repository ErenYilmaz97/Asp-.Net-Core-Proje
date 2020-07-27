using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AspCoreProject.Entity;

namespace AspCoreProjectMVC.Models
{
    public class CustomerUpdateModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen Güncellenecek İsmi Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Güncellenecek Soyismi Giriniz.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Lütfen Güncellenecek Şehri Giriniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen Güncellenecek Ülkeyi Giriniz.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Lütfen Güncellenecek Adresi Giriniz.")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Lütfen Güncellenecek Telefonu Giriniz.")]
        [Phone]
        public string Phone { get; set; }
    }
}
