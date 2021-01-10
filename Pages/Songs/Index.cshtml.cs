using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oltean_Cristina.Data;
using Oltean_Cristina.Models;

namespace Oltean_Cristina.Pages.Songs
{
    public class IndexModel : PageModel
    {
        private readonly Oltean_Cristina.Data.Oltean_CristinaContext _context;

        public IndexModel(Oltean_Cristina.Data.Oltean_CristinaContext context)
        {
            _context = context;
        }

        public IList<Song> Song { get;set; }
        public SongData SongD { get; set; }

        public int SongID { get; set; }

        public int GenreID { get; set; }

        public async Task OnGetAsync(int? id, int? categoryID)

        {

            SongD = new SongData();


            SongD.Songs = await _context.Song

            .Include(b => b.Company)

            .Include(b => b.SongGenres)

            .ThenInclude(b => b.Genre)

            .AsNoTracking()

            .OrderBy(b => b.Title)

            .ToListAsync();

            if (id != null)

            {

                SongID = id.Value;

                Song song = SongD.Songs

                .Where(i => i.ID == id.Value).Single();

                SongD.Genres = song.SongGenres.Select(s => s.Genre);

            }

        }

    }
}
