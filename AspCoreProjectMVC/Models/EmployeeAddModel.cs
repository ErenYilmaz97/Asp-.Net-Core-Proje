using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspCoreProjectMVC.Models
{
    public class EmployeeAddModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen Personel İsmi Giriniz.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Soyismi Giriniz.")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Şehrini Giriniz.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Ülkesini Giriniz.")]
        public string Country { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Adresini Giriniz.")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "Lütfen Personel Telefon Numarasını Giriniz.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
    }
}
