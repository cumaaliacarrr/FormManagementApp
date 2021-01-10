using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FormManagementApp.Entity
{
    public class Form
    {
        public int Id  { get; set; }
        public int UserId  { get; set; }
        public string Name  { get; set; }
        public string Description  { get; set; }
        public DateTime CreatedAt  { get; set; }
        public int CreatedBy  { get; set; }
        [Required(ErrorMessage ="Zorunlu Alan")]
        public string Ad  { get; set; }
        [Required(ErrorMessage = "Zorunlu Alan")]
        public string Soyad  { get; set; }
        public int Yas  { get; set; }
    }
}


