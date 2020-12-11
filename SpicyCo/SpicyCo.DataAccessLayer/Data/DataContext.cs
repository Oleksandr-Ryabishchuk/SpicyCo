using Microsoft.EntityFrameworkCore;
using SpicyCo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyCo.DataAccessLayer.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Product>()
                .Property(i => i.Price).HasColumnType("money");

            builder.Entity<Product>()
                .HasMany(i => i.Orders)
                .WithMany(p => p.Products);

            builder.Entity<Product>()
                .HasOne(i => i.Category)
                .WithMany(v => v.Products)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Product>()
                .HasOne(i => i.SubCategory)
                .WithMany(v => v.Products)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<Product>()
                .HasMany(i => i.Values)
                .WithMany(v => v.Products);

            builder.Entity<Product>()
                .HasMany(i => i.Fields)
                .WithOne(v => v.Product)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Category>()
                .HasMany(s => s.SubCategories)
                .WithOne(c => c.Category)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<SubCategory>()
                .HasMany(v => v.Values)
                .WithOne(s => s.SubCategory)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Value>()
                .HasMany(v => v.Fields)
                .WithOne(s => s.Value)
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<Field> Fields { get; set; }
        public DbSet<Value> Values { get; set; }
        public DbSet<User> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


    }
}
