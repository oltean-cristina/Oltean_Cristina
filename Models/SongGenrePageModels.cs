using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Oltean_Cristina.Data;


namespace Oltean_Cristina.Models
{
    public class SongGenrePageModels : PageModel
    {
        public List<AssignedGenreData> AssignedGenreDataList;

        public void PopulateAssignedGenreData(Oltean_CristinaContext context, Song song)
        {

            var allGenres = context.Genre;

            var songGenres = new HashSet<int>(

            song.SongGenres.Select(c => c.SongID));

            AssignedGenreDataList = new List<AssignedGenreData>();

            foreach (var cat in allGenres)

            {

                AssignedGenreDataList.Add(new AssignedGenreData

                {

                    GenreID = cat.ID,
                    Name = cat.GenreName,
                    Assigned = songGenres.Contains(cat.ID)

                });

            }

        }
        public void UpdateSongGenres(Oltean_CristinaContext context,

string[] selectedGenres, Song songToUpdate)

        {

            if (selectedGenres == null)

            {

                songToUpdate.SongGenres = new List<SongGenre>();

                return;

            }
            var selectedGenresHS = new HashSet<string>(selectedGenres);

            var songGenres = new HashSet<int>

            (songToUpdate.SongGenres.Select(c => c.Genre.ID));
            foreach (var cat in context.Genre)

            {

                if (selectedGenresHS.Contains(cat.ID.ToString()))
                {

                    if (!songGenres.Contains(cat.ID))
                    {

                        songToUpdate.SongGenres.Add(

                        new SongGenre

                        {

                            SongID = songToUpdate.ID,
                            GenreID = cat.ID

                        });

                    }

                }
                else
                {

                    if (songGenres.Contains(cat.ID))
                    {

                        SongGenre courseToRemove

                        = songToUpdate


                        .SongGenres

                        .SingleOrDefault(i => i.GenreID == cat.ID);

                        context.Remove(courseToRemove);

                    }

                }

            }

        }


        }
    }
