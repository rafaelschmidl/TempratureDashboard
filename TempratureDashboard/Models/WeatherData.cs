using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempratureDashboard.Models
{
    public class WeatherData
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public double Temprature { get; set; }
        public int Humidity { get; set; }
    }
}
