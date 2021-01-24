using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using WeatherDashboard.Data;
using WeatherDashboard.Models;

namespace WeatherDashboard.Pages.WeatherData
{
    public class CreateModel : PageModel
    {
        private readonly WeatherDashboard.Data.EFContext _context;

        public CreateModel(WeatherDashboard.Data.EFContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public WeatherDashboard.Models.WeatherData WeatherData { get; set; }

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
