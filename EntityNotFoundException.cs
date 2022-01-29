namespace PatchExample
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(int id) : base($"Entity with id {id} not found.") { }
    }
}
