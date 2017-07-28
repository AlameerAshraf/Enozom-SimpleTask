using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity; 

namespace DataAccessLayer.Models
{
   public class AppDbContext : DbContext
    {
        public AppDbContext() : base("StoreConnection") { } 
        public static AppDbContext Create()
        {
            return new  AppDbContext(); 
        }


        public virtual DbSet<Store> Stores { get; set; }

    }
}
