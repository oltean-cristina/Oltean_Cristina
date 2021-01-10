using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Oltean_Cristina.Data;
using Oltean_Cristina.Models;


namespace Oltean_Cristina.Pages.Songs
{
    public class EditModel : SongGenrePageModels
    {
        private readonly Oltean_Cristina.Data.Oltean_CristinaContext _context;

        public EditModel(Oltean_Cristina.Data.Oltean_CristinaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Song Song { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Song = await _context.Song

.Include(b => b.Company)

.Include(b => b.SongGenres).ThenInclude(b => b.Genre)

.AsNoTracking()

.FirstOrDefaultAsync(m => m.ID == id);


           

            if (Song == null)
            {
                return NotFound();
            }
            PopulateAssignedGenreData(_context, Song);
            ViewData["CompanyID"] = new SelectList(_context.Set<Company>(), "ID", "CompanyName");
           
            return Page();

        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]
selectedGenres)
        {
            if (id == null)

            {

                return NotFound();

            }

            var songToUpdate = await _context.Song

            .Include(i => i.Company)

            .Include(i => i.SongGenres)

            .ThenInclude(i => i.Genre)


            .FirstOrDefaultAsync(s => s.ID == id);

            if (songToUpdate == null)

            {

                return NotFound();

            }

            if (await TryUpdateModelAsync<Song>(

            songToUpdate,

            "Song",

            i => i.Title, i => i.Artist,

            i => i.Price, i => i.ReleaseDate, i => i.Company))

            {

                UpdateSongGenres(_context, selectedGenres, songToUpdate);

                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");

            }
            UpdateSongGenres(_context, selectedGenres, songToUpdate);

            PopulateAssignedGenreData(_context, songToUpdate);

            return Page();

        }

    }

}
