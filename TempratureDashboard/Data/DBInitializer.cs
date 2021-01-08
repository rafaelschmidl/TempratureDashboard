using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempratureDashboard.Data
{
    public class DBInitializer
    {
        public static void Initialize(DBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.WeatherData.Any())
            {
                return;   // DB has been seeded
            }

            var weatherData = new TempratureDashboard.Models.WeatherData[]
            {

                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 13:58:30"), Place="Inne", Temprature=24.8, Humidity=42},
                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 13:59:30"), Place="Inne", Temprature=24.8, Humidity=42},
                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 13:59:43"), Place="Ute", Temprature=25.2, Humidity=39},
                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:00:30"), Place="Inne", Temprature=24.8, Humidity=43},
                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:00:43"), Place="Ute", Temprature=25.3, Humidity=39},
                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:01:30"), Place="Inne", Temprature=24.8, Humidity=42},
                new TempratureDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:01:43"), Place="Ute", Temprature=25.3, Humidity=39}
            };

            context.WeatherData.AddRange(weatherData);
            context.SaveChanges();
        }
    }
}
