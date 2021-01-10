using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oltean_Cristina.Models
{
    public class Genre
    {
        public int ID { get; set; }

        public string GenreName { get; set; }

        public ICollection<SongGenre> SongGenres { get; set; }

    }
}
