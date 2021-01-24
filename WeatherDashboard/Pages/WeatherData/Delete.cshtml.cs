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
    public class DeleteModel : PageModel
    {
        private readonly WeatherDashboard.Data.EFContext _context;

        public DeleteModel(WeatherDashboard.Data.EFContext context)
        {
            _context = context;
        }

        [BindProperty]
        public WeatherDashboard.Models.WeatherData WeatherData { get; set; }

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            WeatherData = await _context.WeatherData.FindAsync(id);

            if (WeatherData != null)
            {
                _context.WeatherData.Remove(WeatherData);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
