using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Data;
using VinylWorld.Domain;

namespace VinylWorld.Infrastructure
{
    public static class ApplicationBuilderExtension
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();

            var services = serviceScope.ServiceProvider;

            await RoleSeeder(services);
            await SeedAdministrator(services);

            //var dataGenre = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //SeedGenres(dataGenre);

            //var dataArtist = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            //SeedArtists(dataArtist);

            var dataGenre = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedGenres(dataGenre);

            var dataArtist = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
            SeedArtists(dataArtist);
            return app;
        }
    
    public static async Task RoleSeeder(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        string[] roleNames = { "Administrator", "Client" };

        IdentityResult roleResult;
        foreach (var role in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(role);
            if (!roleExist)
            {
                roleResult = await roleManager.CreateAsync(new IdentityRole(role));
            }
        }
    }

        public static async Task SeedAdministrator(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            if (await userManager.FindByNameAsync("admin") == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.FirstName = "admin";
                user.LastName = "admin";
                user.PhoneNumber = "0888888888";
                user.UserName = "admin";
                user.Email = "admin@admin.com";

                var result = await userManager.CreateAsync(user, "admin123");

                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Administrator").Wait();
                }
            }
        }
        public static void SeedGenres(ApplicationDbContext dataGenre)
        {
            if (dataGenre.Genres.Any())
            {
                return;
            }

            dataGenre.Genres.AddRange(new[]
            {
                new Genre{GenreName="Hip-Hop"},
                new Genre{GenreName="RnB"},
                new Genre{GenreName="Pop"},
                new Genre{GenreName="Rock"},
                new Genre{GenreName="Jazz"},
                new Genre{GenreName="Metal"},
                new Genre{GenreName="Soul"}
            });
            dataGenre.SaveChanges();
        }

        public static void SeedArtists(ApplicationDbContext dataArtist)
        {
            if (dataArtist.Artists.Any())
            {
                return;
            }

            dataArtist.Artists.AddRange(new[]
            {
                new Artist{ArtistName="Kanye West"},
                new Artist{ArtistName="The Weeknd"},
                new Artist{ArtistName="Fka Twigs"},
                new Artist{ArtistName="The Beatles"},
                new Artist{ArtistName="Miles Davis"},
                new Artist{ArtistName="Metallica"},
                new Artist{ArtistName="Marvin Gaye"},
                new Artist{ArtistName="Freddie Gibbs"},
            });
            dataArtist.SaveChanges();
        }

    }
}
