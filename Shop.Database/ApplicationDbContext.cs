using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shop.Database
{
   public class ApplicationDbContext : IdentityDbContext
    {

       public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {}
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderStuck> OrderStucks { get; set; }
        public DbSet<StockOnHold> StocskOnHold { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<OrderStuck>()
                .HasKey(X => new { X.StockId, X.OrderId });
        }

    }
}