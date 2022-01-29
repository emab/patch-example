using Microsoft.AspNetCore.Mvc;
using PatchExample.Service;

namespace PatchExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IWeatherService _weatherService;

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        [HttpGet]
        public List<Weather> GetAll()
        {
            return _weatherService.GetAll();
        }

        [HttpGet("{id}")]
        public Weather GetById(int id)
        {
            return _weatherService.GetById(id);
        }

        [HttpPatch("{id}")]
        public Weather Update(int id, WeatherUpdate weather)
        {
            return _weatherService.Update(id, weather);
        }
    }
}