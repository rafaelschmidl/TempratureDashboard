using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WeatherDashboard.Data;
using WeatherDashboard.Models;

namespace WeatherDashboard.Pages.WeatherData
{
    public class DetailsModel : PageModel
    {
        private readonly EFContext _context;

        public DetailsModel(EFContext context)
        {
            _context = context;
        }

        public Models.WeatherData WeatherData { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeatherData = await _context.WeatherData.FirstOrDefaultAsync(m => m.ID == id);

            if (WeatherData == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
