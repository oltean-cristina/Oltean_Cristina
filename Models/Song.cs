using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Oltean_Cristina.Models
{
    public class Song
    {
        public int ID { get; set; }
        [Display(Name = "Song")]
        [Required, StringLength(150, MinimumLength = 3)]

        public string Title { get; set; }
        [Display(Name = "Name of the Artist")]
        [Required, StringLength(150, MinimumLength = 3)]

        public string Artist { get; set; }
        [Display(Name = "Album Price")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(1, 300)]

        public decimal Price { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }
        public int CompanyID { get; set; }
        [Display(Name = "Music Recordings Companies")]
        public Company Company { get; set; }
        [Display(Name = "Genres")]
        public ICollection<SongGenre> SongGenres { get; set; }


    


    }
}
