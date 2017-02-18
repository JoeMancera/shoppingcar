using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class Producto
    {
        public int Id { get; set; }

        #region Nombre del Producto
        public string Nombre { get; set; }
        #endregion

        #region Precio
        public float Precio { get; set; }
        #endregion
    }
}