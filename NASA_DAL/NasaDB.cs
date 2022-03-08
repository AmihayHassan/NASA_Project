using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using NASA_BE;

//https://docs.microsoft.com/en-us/aspnet/mvc/overview/getting-started/getting-started-with-ef-using-mvc/creating-an-entity-framework-data-model-for-an-asp-net-mvc-application

namespace NASA_DAL
{
    public class NasaDB : DbContext
    {
        public NasaDB() : base()

        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Planet> Planets { get; set; }
        public DbSet<Comet> Comets { get; set; }
        public DbSet<Asteroid> Asteroids { get; set; }

    }
}