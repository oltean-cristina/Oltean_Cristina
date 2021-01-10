using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Oltean_Cristina.Models;

namespace Oltean_Cristina.Data
{
    public class Oltean_CristinaContext : DbContext
    {
        public Oltean_CristinaContext (DbContextOptions<Oltean_CristinaContext> options)
            : base(options)
        {
        }

        public DbSet<Oltean_Cristina.Models.Song> Song { get; set; }

        public DbSet<Oltean_Cristina.Models.Company> Company { get; set; }

        public DbSet<Oltean_Cristina.Models.Genre> Genre { get; set; }



      
    }
}
