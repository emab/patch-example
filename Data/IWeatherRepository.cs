namespace PatchExample.Data
{
    public interface IWeatherRepository
    {
        Weather Get(int id);
        IEnumerable<Weather> GetAll();
        Weather Update(int id, WeatherUpdate weather);
    }
}
