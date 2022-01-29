using System.ComponentModel.DataAnnotations;

namespace PatchExample
{
    public class Weather
    {
        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public double Temperature { get; set; }
        public double WindSpeed { get; set; }
        public double Rain { get; set; }

        public Weather(int id, string city, string country, double temperature, double windSpeed, double rain)
        {
            Id = id;
            City = city;
            Country = country;
            Temperature = temperature;
            WindSpeed = windSpeed;
            Rain = rain;
        }
    }
}
