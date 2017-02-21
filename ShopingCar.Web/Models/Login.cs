using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class Login
    {
        [Display(Name = "Correo")]
        [Required]
        public string correo { get; set; }
        [Display(Name = "Contraseña")]
        [Required]
        public string clave { get; set; }
    }
}