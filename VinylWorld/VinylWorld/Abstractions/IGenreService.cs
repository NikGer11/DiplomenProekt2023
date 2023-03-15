using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Domain;

namespace VinylWorld.Abstractions
{
     public interface IGenreService
    {
        List<Genre> GetGenres();

        Genre GetGenreById(int genreId);

        List<Album> GetAlbumsByGenre(int genreId);
    }
}
