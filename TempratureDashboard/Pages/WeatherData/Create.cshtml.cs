using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TempratureDashboard.Data;
using TempratureDashboard.Models;

namespace TempratureDashboard.Pages.WeatherData
{
    public class CreateModel : PageModel
    {
        private readonly TempratureDashboard.Data.DBContext _context;

        public CreateModel(TempratureDashboard.Data.DBContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public TempratureDashboard.Models.WeatherData WeatherData { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.WeatherData.Add(WeatherData);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
