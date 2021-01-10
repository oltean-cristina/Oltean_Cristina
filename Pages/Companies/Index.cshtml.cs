using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Oltean_Cristina.Data;
using Oltean_Cristina.Models;

namespace Oltean_Cristina.Pages.Companies
{
    public class IndexModel : PageModel
    {
        private readonly Oltean_Cristina.Data.Oltean_CristinaContext _context;

        public IndexModel(Oltean_Cristina.Data.Oltean_CristinaContext context)
        {
            _context = context;
        }

        public IList<Company> Company { get;set; }

        public async Task OnGetAsync()
        {
            Company = await _context.Company.ToListAsync();
        }
    }
}
