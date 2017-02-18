using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class Persona
    {
        public int Id { get; set; }

        #region Nombre Persona
        [Display(Name ="Nombre")]
        [Required]
        public string Nombre { get; set; }
        #endregion

        #region Correo
        [Display(Name = "Correo")]
        [Required]
        public string Correo { get; set; }
        #endregion

        #region Teléfono
        [Display(Name = "Teléfono")]
        public int telefono { get; set; }
        #endregion

        #region  Dirección
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }
        #endregion

        #region Relacion con Usuario
        public virtual Usuario Usuarios { get; set; }
        #endregion

    }
}