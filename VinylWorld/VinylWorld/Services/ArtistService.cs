using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Abstractions;
using VinylWorld.Data;
using VinylWorld.Domain;

namespace VinylWorld.Services
{
    public class ArtistService : IArtistService
    {
        private readonly ApplicationDbContext _context;

        public ArtistService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Artist GetArtistById(int artistId)
        {
            return _context.Artists.Find(artistId);
        }

        public List<Artist> GetArtists()
        {
            List<Artist> artists = _context.Artists.ToList();
            return artists;
        }

        public List<Album> GetAlbumsByArtist(int artistId)
        {
            return _context.Albums
                .Where(x => x.ArtistId == artistId)
                .ToList();
        }
      
    }
}
