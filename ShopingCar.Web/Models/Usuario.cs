using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        #region Persona
        [Display(Name = "Persona")]
        [Required]
        public int PersonaId { get; set; }
        #endregion

        #region Correo
        [EmailAddress]
        [Required]
        public string Corrreo { get; set; }
        #endregion

        #region contraseña
        [Display(Name = "Persona")]
        [DataType(DataType.Password)]
        [Required]
        public string clave { get; set; }
        #endregion

        #region relacion con personas
        public virtual ObservableCollection<Persona> Personas { get; set; }
        #endregion
    }
}