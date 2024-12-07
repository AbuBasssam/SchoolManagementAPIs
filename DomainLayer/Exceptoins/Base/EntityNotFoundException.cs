namespace DomainLayer
{
    public abstract class EntityNotFoundException : Exception
    {
        protected EntityNotFoundException(string message): base(message)
        {
        }
    }
}
