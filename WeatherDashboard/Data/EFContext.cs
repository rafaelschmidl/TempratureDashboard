using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WeatherDashboard.Models;

namespace WeatherDashboard.Data
{
    public class EFContext : DbContext
    {
        public EFContext (DbContextOptions<EFContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherDashboard.Models.WeatherData> WeatherData { get; set; }
    }
}
