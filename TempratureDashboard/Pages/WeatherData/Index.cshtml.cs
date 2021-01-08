using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TempratureDashboard.Data;
using TempratureDashboard.Models;

namespace TempratureDashboard.Pages.WeatherData
{
    public class IndexModel : PageModel
    {
        private readonly TempratureDashboard.Data.DBContext _context;

        public IndexModel(TempratureDashboard.Data.DBContext context)
        {
            _context = context;
        }

        public IList<TempratureDashboard.Models.WeatherData> WeatherData { get;set; }

        public async Task OnGetAsync()
        {
            WeatherData = await _context.WeatherData.ToListAsync();
        }
    }
}
