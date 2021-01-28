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
