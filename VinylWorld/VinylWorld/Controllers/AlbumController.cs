using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Abstractions;
using VinylWorld.Domain;
using VinylWorld.Models.Album;
using VinylWorld.Models.Artist;
using VinylWorld.Models.Genre;

namespace VinylWorld.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;
        private readonly IGenreService _genreService;
        private readonly IArtistService _artistService;

        public AlbumController(IAlbumService albumService, IGenreService genreService, IArtistService artistService)
        {
            this._albumService = albumService;
            this._genreService = genreService;
            this._artistService = artistService;
        }

        public ActionResult Create()
        {
            var album = new AlbumCreateVM();
            album.Artists = _artistService.GetArtists()
                .Select(x => new ArtistPairVM()
                {
                    Id = x.Id,
                    Name = x.ArtistName
                }).ToList();
            album.Genres = _genreService.GetGenres()
               .Select(x => new GenrePairVM()
               {
                   Id = x.Id,
                   Name = x.GenreName
               }).ToList();
            return View(album);

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] AlbumCreateVM album)
        {
            if (ModelState.IsValid)
            {
                var createdId = _albumService.Create(album.AlbumName, album.ArtistId,
                                                       album.GenreId, album.Picture,
                                                       album.Quantity, album.Price, album.Discount);
                if (createdId)
                {
                    return RedirectToAction(nameof(Index));
                }
            }

            return View();

        }
       
        [AllowAnonymous]
        public IActionResult Index(string searchStringGenreName, string searchStringArtistName)
        {
            List<AlbumIndexVM> albums = _albumService.GetAlbums(searchStringGenreName, searchStringArtistName)
            .Select(album => new AlbumIndexVM
            {
                Id = album.Id,
                AlbumName = album.AlbumName,
                ArtistId = album.ArtistId,
                ArtistName = album.Artist.ArtistName,
                GenreId = album.GenreId,
                GenreName = album.Genre.GenreName,
                Picture = album.Picture,
                Quantity = album.Quantity,
                Price = album.Price,
                Discount = album.Discount

            }).ToList();
            return this.View(albums);
        }

        public ActionResult Edit(int id)
        {
            Album album = _albumService.GetAlbumById(id);
            if (album == null)
            {
                return NotFound();
            }

            AlbumEditVM updatedAlbum = new AlbumEditVM()
            {
                Id = album.Id,
                AlbumName = album.AlbumName,
                ArtistId = album.ArtistId,
                // ArtistName = album.Artist.ArtistName,
                GenreId = album.GenreId,
                //GenreName = album.Genre.GenreName,
                Picture = album.Picture,
                Quantity = album.Quantity,
                Price = album.Price,
                Discount = album.Discount
            };
            updatedAlbum.Artists = _artistService.GetArtists()
                .Select(b => new ArtistPairVM()
                {
                    Id = b.Id,
                    Name = b.ArtistName
                })
                .ToList();

            updatedAlbum.Genres = _genreService.GetGenres()
                .Select(c => new GenrePairVM()
                {
                    Id = c.Id,
                    Name = c.GenreName
                })
                .ToList();
            return View(updatedAlbum);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, AlbumEditVM album)
        {
            {
                if (ModelState.IsValid)
                {
                    var updated = _albumService.Update(id, album.AlbumName, album.ArtistId, album.GenreId, album.Picture, album.Quantity, album.Price, album.Discount);

                    if (updated)
                    {
                        return this.RedirectToAction("Index");
                    }
                }
                return View(album);
            }            
        }
        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Album item = _albumService.GetAlbumById(id);
            if (item == null)
            {
                return NotFound();
            }
            AlbumDetailsVM album = new AlbumDetailsVM()
            {
                Id = item.Id,
                AlbumName = item.AlbumName,
                ArtistId = item.ArtistId,
                //AlbumName = item.Artist.ArtistName,
                GenreId = item.GenreId,
                //GenreName = item.Genre.GenreName,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(album);
        }
        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            Album item = _albumService.GetAlbumById(id);
            if (item == null)
            {
                return NotFound();
            }
            AlbumDeleteVM album = new AlbumDeleteVM()
            {
                Id = item.Id,
                AlbumName = item.AlbumName,
                ArtistId = item.ArtistId,
                ArtistName = item.Artist.ArtistName,
                GenreId = item.GenreId,
                GenreName = item.Genre.GenreName,
                Picture = item.Picture,
                Quantity = item.Quantity,
                Price = item.Price,
                Discount = item.Discount
            };
            return View(album);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)


        {
            var deleted = _albumService.RemoveById(id);

            if (deleted)
            {
                return this.RedirectToAction("Success");
            }
            else
            {
                return View();
            }
        }
        public IActionResult Success()
        {
            return View();
        }
    }
}
