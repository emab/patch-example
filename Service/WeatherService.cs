using PatchExample.Data;

namespace PatchExample.Service
{
    public interface IWeatherService { 
        List<Weather> GetAll();
        Weather GetById(int id);
        Weather Update(int id, WeatherUpdate weather);
    }

    public class WeatherService : IWeatherService
    {
        private readonly IWeatherRepository _weatherRepository;

        public WeatherService(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }

        public List<Weather> GetAll() => new List<Weather>(_weatherRepository.GetAll());
        

        public Weather GetById(int id) => _weatherRepository.Get(id);
        

        public Weather Update(int id, WeatherUpdate weather) =>_weatherRepository.Update(id, weather);

        
    }
}
