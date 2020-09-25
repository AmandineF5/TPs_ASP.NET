using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OGameApp.Data
{
    public class OGameAppContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public OGameAppContext() : base("name=OGameAppContext")
        {
        }

        public System.Data.Entity.DbSet<OGameLibrary.Entities.Planet> Planets { get; set; }

        public System.Data.Entity.DbSet<OGameLibrary.Entities.Resource> Resources { get; set; }

        public System.Data.Entity.DbSet<OGameLibrary.Entities.SolarSystem> SolarSystems { get; set; }
    }
}
