﻿
using BO_Dojo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TP_Dojo.Data
{
    public class TP_DojoContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TP_DojoContext() : base("name=TP_DojoContext")
        {
        }

        public System.Data.Entity.DbSet<BO_Dojo.Samourai> Samourais { get; set; }

        public System.Data.Entity.DbSet<BO_Dojo.Arme> Armes { get; set; }

        public System.Data.Entity.DbSet<BO_Dojo.ArtMartial> ArtMartials { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //une Arme ne peut appartenir qu’à un seul samouraï
            modelBuilder.Entity<Samourai>().HasOptional(x => x.Arme).WithOptionalPrincipal();

            //Un samouraï possède désormais une liste d’arts martiaux
            //Un art martial peut être associé à zéro ou plusieurs samouraïs
            modelBuilder.Entity<Samourai>().HasMany(x => x.ArtMartials).WithMany();

        }

        
    }
}
