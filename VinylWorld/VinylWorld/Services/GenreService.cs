using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Abstractions;
using VinylWorld.Data;
using VinylWorld.Domain;

namespace VinylWorld.Services
{
    public class GenreService : IGenreService
    {
        private readonly ApplicationDbContext _context;

        public GenreService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Genre GetGenreById(int genreId)
        {
            return _context.Genres.Find(genreId);
        }

        public List<Genre> GetGenres()
        {
            List<Genre> genres = _context.Genres.ToList();
            return genres;
        }

        public List<Album> GetAlbumsByGenre(int genreId)
        {
            return _context.Albums
                .Where(x => x.GenreId == genreId)
                .ToList();
        }
    }
}
