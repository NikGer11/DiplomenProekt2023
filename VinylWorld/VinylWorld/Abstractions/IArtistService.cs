using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Domain;

namespace VinylWorld.Abstractions
{
    public interface IArtistService
    {
        List<Artist> GetArtists();

        Artist GetArtistById(int artistId);

        List<Album> GetAlbumsByArtist(int artistId);
    }
}
