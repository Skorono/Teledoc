namespace Teledoc.Core.Exceptions.Entities;

public class EntityAlreadyExists : ExceptionBase
{
    public EntityAlreadyExists(string message) : base(message)
    {
    }
}