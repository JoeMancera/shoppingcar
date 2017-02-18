using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShopingCar.Web.Models
{
    public class ShopingCarWebContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public ShopingCarWebContext() : base("name=ShopingCarWebContext")
        {
            Database.SetInitializer<ShopingCarWebContext>(
                   new DropCreateDatabaseIfModelChanges<ShopingCarWebContext>()
             );
            //Recrea la base de datos con respecto al modelo de datos que tenemos en el proyecto
            //en produccion se debera crear una strategis como MigrateDatabaseToLatestVersion o similares
        }

        public System.Data.Entity.DbSet<ShopingCar.Web.Models.DetallePedido> DetallePedidoes { get; set; }

        public System.Data.Entity.DbSet<ShopingCar.Web.Models.Pedido> Pedidoes { get; set; }

        public System.Data.Entity.DbSet<ShopingCar.Web.Models.Persona> Personas { get; set; }

        public System.Data.Entity.DbSet<ShopingCar.Web.Models.Producto> Productoes { get; set; }

        public System.Data.Entity.DbSet<ShopingCar.Web.Models.Usuario> Usuarios { get; set; }

        public System.Data.Entity.DbSet<ShopingCar.Web.Models.Home> Homes { get; set; }
    }
}
