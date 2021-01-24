using System;
using System.ComponentModel.DataAnnotations;

namespace WeatherDashboard.Models
{
    public class WeatherData
    {
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required, MaxLength(64)]
        public string Place { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
    }
}
