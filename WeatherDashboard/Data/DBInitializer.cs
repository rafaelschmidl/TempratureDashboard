using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherDashboard.Data
{
    public class DBInitializer
    {
        public static void Initialize(EFContext context)
        {
            context.Database.EnsureCreated();

            if (context.WeatherData.Any())
            {
                return;   // DB has already been seeded
            }

            //var weatherData = new WeatherDashboard.Models.WeatherData[]
            //{

            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 13:58:30"), Place="Inne", Temperature=24.8, Humidity=42},
            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 13:59:30"), Place="Inne", Temperature=24.8, Humidity=42},
            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 13:59:43"), Place="Ute", Temperature=25.2, Humidity=39},
            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:00:30"), Place="Inne", Temperature=24.8, Humidity=43},
            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:00:43"), Place="Ute", Temperature=25.3, Humidity=39},
            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:01:30"), Place="Inne", Temperature=24.8, Humidity=42},
            //    new WeatherDashboard.Models.WeatherData{Date=DateTime.Parse("2016-05-31 14:01:43"), Place="Ute", Temperature=25.3, Humidity=39}
            //};

            using StreamReader sr = new StreamReader("TemperaturData.csv");

            string[] weatherDataStringArray = sr.ReadToEnd().Split("\r\n");

            var weatherData = new List<Models.WeatherData>();

            int counter = 0;
            int batchSize = 2000;

            foreach (string item in weatherDataStringArray)
            {
                string[] dataStringArray = item.Split(",");

                weatherData.Add(new Models.WeatherData { Date = DateTime.Parse(dataStringArray[0]), Place = dataStringArray[1], Temperature = double.Parse(dataStringArray[2]), Humidity = double.Parse(dataStringArray[3]) });

                counter++;

                if(counter >= batchSize)
                {
                    context.AddRange(weatherData);
                    context.SaveChanges();
                    weatherData = new List<Models.WeatherData>();
                    counter = 0;
                }
            }

            context.AddRange(weatherData);
            context.SaveChanges();
        }
    }
}
