using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Oltean_Cristina.Data;
using Oltean_Cristina.Models;

namespace Oltean_Cristina.Pages.Songs
{
    public class CreateModel : SongGenrePageModels
    {
        private readonly Oltean_Cristina.Data.Oltean_CristinaContext _context;

        public CreateModel(Oltean_Cristina.Data.Oltean_CristinaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CompanyID"] = new SelectList(_context.Set<Company>(), "ID", "CompanyName");

            var song = new Song();

            song.SongGenres = new List<SongGenre>();


            PopulateAssignedGenreData(_context, song);

            return Page();
        }

        [BindProperty]
        public Song Song { get; set; }


        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(string[] selectedGenres)

        {

            var newSong = new Song();

            if (selectedGenres != null)

            {

                newSong.SongGenres = new List<SongGenre>();

                foreach (var cat in selectedGenres)

                {

                    var catToAdd = new SongGenre

                    {
                        GenreID = int.Parse(cat)

                    };
                    newSong.SongGenres.Add(catToAdd);

                }

            }

            if (await TryUpdateModelAsync<Song>(

            newSong,

            "Song",

            i => i.Title, i => i.Artist,

            i => i.Price, i => i.ReleaseDate, i => i.CompanyID))

            {

                _context.Song.Add(newSong);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");

            }

            PopulateAssignedGenreData(_context, newSong);

            return Page();

        }

    }
}
