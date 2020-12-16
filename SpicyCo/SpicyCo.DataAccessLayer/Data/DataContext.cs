using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SpicyCo.DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpicyCo.DataAccessLayer.Data
{
    public class DataContext: IdentityDbContext<User, Role, Guid,
        IdentityUserClaim<Guid>, UserRole, IdentityUserLogin<Guid>,
        IdentityRoleClaim<Guid>, IdentityUserToken<Guid>>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserRole>(userRole =>
            {
                userRole.HasKey(ur => new { ur.UserId, ur.RoleId });

                userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
            });

            builder.Entity<Product>()
                .Property(i => i.Price).HasColumnType("money");

            builder.Entity<Product>()
                .HasMany(i => i.Orders)
                .WithMany(p => p.Products);
           
            builder.Entity<Product>()
                .HasOne(i => i.User)
                .WithMany(prop=> prop.Products)
                .OnDelete(DeleteBehavior.NoAction);

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
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }


    }
}
