using Microsoft.EntityFrameworkCore;
using ShopWeb.Data.Entities;
using System.Data.SqlClient;

namespace ShopWeb.Data.Context
{
    public class ShopDBContext : DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options) : base(options)
        {

        }

        public DbSet<Products> Products { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Suppliers> Suppliers { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}
