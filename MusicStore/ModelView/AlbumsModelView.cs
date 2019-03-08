using Microsoft.AspNetCore.Mvc.Rendering;
using MusicStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MusicStore.ModelView
{
    public class AlbumsModelView
    {
        public List<Album> Albums { get; set; }
        public SelectList Artists { get; set; }
        public SelectList Genres { get; set; }

        public int GenreID { get; set; }
        public int ArtistID { get; set; }
        public string Keyword { get; set; }
    }
}
