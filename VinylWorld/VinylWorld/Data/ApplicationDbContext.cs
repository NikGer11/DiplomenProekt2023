using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using VinylWorld.Domain;
using VinylWorld.Models.Album;

namespace VinylWorld.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<VinylWorld.Models.Album.AlbumIndexVM> AlbumIndexVM { get; set; }
        public DbSet<VinylWorld.Models.Album.AlbumDeleteVM> AlbumDeleteVM { get; set; }
        //public DbSet<VinylWorld.Models.Album.AlbumCreateVM> AlbumCreateVM { get; set; }
        //public DbSet<VinylWorld.Models.Album.AlbumIndexVM> AlbumIndexVM { get; set; }
        //public DbSet<VinylWorld.Models.Album.AlbumEditVM> AlbumEditVM { get; set; }
        //public DbSet<VinylWorld.Models.Album.AlbumDetailsVM> AlbumDetailsVM { get; set; }
    }
}
