using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Domain;

namespace VinylWorld.Abstractions
{
    public interface IAlbumService
    {
        bool Create(string name, int artistId, int genreId, string picture, int quantity, decimal price, decimal discount);

        bool Update(int albumId, string name, int artistId, int genreId, string picture, int quantity, decimal price, decimal discount);

        List<Album> GetAlbums();

        Album GetAlbumById(int albumId);

        bool RemoveById(int albumId);

        List<Album> GetAlbums(string searchStringGenreName, string searchStringArtistName);
    } 
}
