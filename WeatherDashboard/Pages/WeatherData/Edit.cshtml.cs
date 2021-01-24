﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WeatherDashboard.Data;
using WeatherDashboard.Models;

namespace WeatherDashboard.Pages.WeatherData
{
    public class EditModel : PageModel
    {
        private readonly EFContext _context;

        public EditModel(EFContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(WeatherData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WeatherDataExists(WeatherData.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool WeatherDataExists(int id)
        {
            return _context.WeatherData.Any(e => e.ID == id);
        }
    }
}