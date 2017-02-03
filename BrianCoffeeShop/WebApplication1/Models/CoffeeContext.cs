using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class CoffeeContext : DbContext
    {
        public CoffeeContext()
            : base("BrianCoffeeShopDB")
        {
            //Name for Azure DB = BrianCoffeeShop
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Coffee> Coffees { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}