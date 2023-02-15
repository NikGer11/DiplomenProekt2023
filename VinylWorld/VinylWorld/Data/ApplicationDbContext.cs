using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VinylWorld.Domain;

namespace VinylWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<Purchase> Purchase { get; set; }
        public DbSet<Vinyl> Vinyl { get; set; }
        public DbSet<Genre> Genre { get; set; }
    }
}
