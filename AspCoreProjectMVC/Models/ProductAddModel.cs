using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspCoreProjectMVC.Models
{
    public class ProductAddModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Lütfen Ürün İsmini Giriniz.")]
        public string Product { get; set; }

        [Required(ErrorMessage = "Lütfen Kategori Seçiniz.")]
        public int CategoryID { get; set; }

        [Required(ErrorMessage = "Lütfen Firma Seçiniz.")]
        public int CompanyID { get; set; }

        [Required(ErrorMessage = "Lütfen Ürün Fiyatı Giriniz.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Lütfen Adet Bilgisi Giriniz.")]
        public string QuantityPerUnit { get; set; }

        public List<SelectListItem> CategorySelectList { get; set; }
        public List<SelectListItem> CompanySelecList { get; set; }


    }
}
