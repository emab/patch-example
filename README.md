# PatchExample

A way of handling a `patch` request without any extra dependencies. This method allows one or more properties to be updated in one go (limitation being that they cannot be set to null).

## Important Files

### `Weather.cs`

This is the main model for the database, and contains all of the properties of the object.

### `WeatherUpdate.cs`

This is the update object. This should contain any properties of the above file that should be updatable. Any properties must match the above objects properties exactly.

### `WeatherRepository.cs`

Contains the actual implmenetation for updating the existing entity properties with the ones from the update model.

```cs
public Weather Update(int id, WeatherUpdate updateObject)
{
    // find existing entity
    var existingEntity = _context.Weather.Find(id);
    
    // handle not found
    if (existingEntity == null)
    {
        throw new EntityNotFoundException(id);
    }

    // iterate through all of the properties of the update object
    // in this example it includes all properties apart from `id`
    foreach (PropertyInfo prop in updateObject.GetType().GetProperties())
    {
        // check if the property has been set in the updateObject
        // if it is null we ignore it. If you want to allow null values to be set, you could add a flag to the update object to allow specific nulls
        if (prop.GetValue(updateObject) != null)
        {
            // if it has been set update the existing entity value
            existingEntity.GetType().GetProperty(prop.Name)?.SetValue(existingEntity, prop.GetValue(updateObject));               
        }
    }
    _context.SaveChanges();
    return existingEntity;
}
```