using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TempratureDashboard.Models;

namespace TempratureDashboard.Data
{
    public class DBContext : DbContext
    {
        public DBContext (DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<TempratureDashboard.Models.WeatherData> WeatherData { get; set; }
    }
}
