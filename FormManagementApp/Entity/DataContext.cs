using FormManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace FormManagementApp.Entity
{
    public class DataContext : DbContext
    {
        public DataContext() : base("dataConnection")
        {
            Database.SetInitializer(new DataInitializer());
        }
        public DbSet<User> UserModels{ get; set; }
        public DbSet<Form> FormModels  { get; set; }

    }
}