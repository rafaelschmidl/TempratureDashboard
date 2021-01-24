using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using WeatherDashboard.Data;
using WeatherDashboard.Models;

namespace WeatherDashboard.Pages.WeatherData
{
    public class IndexModel : PageModel
    {
        private readonly EFContext _context;
        private readonly MvcOptions _mvcOptions;

        public IndexModel(EFContext context, IOptions<MvcOptions> mvcOptions)
        {
            _context = context;
            _mvcOptions = mvcOptions.Value;
        }

        public IList<Models.WeatherData> WeatherData { get; set; }

        public async Task OnGetAsync()  
        {
            WeatherData = await _context.WeatherData
                .Take(_mvcOptions.MaxModelBindingCollectionSize)
                .OrderBy(wd => wd.ID)
                .ToListAsync();
        }
    }
}
