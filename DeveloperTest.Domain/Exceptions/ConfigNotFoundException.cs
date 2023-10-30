namespace DeveloperTest.Domain.Exceptions;

public class ConfigNotFoundException : Exception
{
    public ConfigNotFoundException(string message)
        : base(message)
    {
    }
}
