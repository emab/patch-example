using System.Reflection;

namespace PatchExample.Data
{
    public class WeatherRepository : IWeatherRepository 
    {
        private readonly WeatherContext _context;

        public WeatherRepository(WeatherContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        public Weather Get(int id)
        {
            var result = _context.Weather.Find(id);

            if (result == null)
            {
                throw new EntityNotFoundException(id);
            }

            return result;
        }

        public IEnumerable<Weather> GetAll()
        {
            return _context.Weather.ToList();
        }

        public Weather Update(int id, WeatherUpdate updateObject)
        {
            // find existing entity
            var existingEntity = _context.Weather.Find(id);
            if (existingEntity == null)
            {
                throw new EntityNotFoundException(id);
            }

            // iterate through all of the properties of the update object
            foreach (PropertyInfo prop in updateObject.GetType().GetProperties())
            {
                // check if the property has been set in the updateObject
                if (prop.GetValue(updateObject) != null)
                {
                    // if it has been set update the existing entity value
                    existingEntity.GetType().GetProperty(prop.Name)?.SetValue(existingEntity, prop.GetValue(updateObject));               
                }
            }
            _context.SaveChanges();
            return existingEntity;
        }
    }
}
