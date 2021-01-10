using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oltean_Cristina.Models
{
    public class Company
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
