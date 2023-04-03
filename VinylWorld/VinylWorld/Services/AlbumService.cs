using System;
using System.Collections.Generic;
using System.Linq;
using VinylWorld.Abstractions;
using VinylWorld.Data;
using VinylWorld.Domain;

namespace VinylWorld.Services
{
    public class AlbumService : IAlbumService
    {
        private readonly ApplicationDbContext _context;

        public AlbumService(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Create(string name, int artistId, int genreId, string picture, int quantity, decimal price, decimal discount)
        {
            Album item = new Album
            {
                AlbumName = name,
                Artist = _context.Artists.Find(artistId),
                Genre = _context.Genres.Find(genreId),

                Picture = picture,
                Quantity = quantity,
                Price = price,
                Discount = discount
            };
            _context.Albums.Add(item);
            return _context.SaveChanges() != 0;
        }

        public Album GetAlbumById(int albumId)
        {
            return _context.Albums.Find(albumId);
        }

        public List<Album> GetAlbums()
        {
            List<Album> albums = _context.Albums.ToList();
            return albums;
        }

       

        public bool RemoveById(int albumId)
        {
            var album = GetAlbumById(albumId);
            if (album == default(Album))
            {
                return false;
            }
            _context.Remove(album);
            return _context.SaveChanges() != 0;
        }

        public bool Update(int albumId, string name,int artistId, int genreId, string picture, int quantity, decimal price, decimal discount)
        {
            var album = GetAlbumById(albumId);
            if (album == default(Album))
            {
                return false;
            }
            album.AlbumName = name;

            album.Artist = _context.Artists.Find(albumId);
            album.Genre = _context.Genres.Find(genreId);

            album.Picture = picture;
            album.Quantity = quantity;
            album.Price = price;
            album.Discount = discount;
            _context.Update(album);
            return _context.SaveChanges() != 0;

        }

        public List<Album> GetAlbums(string searchStringGenreName, string searchStringArtistName)
        {
            List<Album> albums = _context.Albums.ToList();
            if (!String.IsNullOrEmpty(searchStringGenreName) && !String.IsNullOrEmpty(searchStringArtistName))
            {
                albums = albums.Where(x => x.Genre.GenreName.ToLower().Contains(searchStringGenreName.ToLower())
                && x.Artist.ArtistName.ToLower().Contains(searchStringArtistName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringGenreName))
            {
                albums = albums.Where(x => x.Genre.GenreName.ToLower().Contains(searchStringGenreName.ToLower())).ToList();
            }
            else if (!String.IsNullOrEmpty(searchStringArtistName))
            {
                albums = albums.Where(x => x.Artist.ArtistName.ToLower().Contains(searchStringArtistName.ToLower())).ToList();
            }
            return albums;
        }

        
    }
}



