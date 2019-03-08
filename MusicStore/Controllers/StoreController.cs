using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicStore.Data;
using MusicStore.Models;

namespace MusicStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly StoreContext _context;

        public StoreController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListGenres()
        {
            var genres = _context.Genres.OrderBy(g => g.Name);
            return View(genres);
        }

        public IActionResult ListAlbums(int? id)
        {
            var albums = new List<Album>();
            if (id != null && id != 0)
            {
                albums = _context.Albums.Include(a => a.Genre).Where(a => a.GenreID == id).OrderBy(a => a.Title).ToList();
            }

            return View(albums);
        }

        public IActionResult Details(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            var album = _context.Albums.Include(a => a.Genre).Include(a => a.Artist).Where(a => a.AlbumID == id).Single();

            return View(album);
        }
    }
}