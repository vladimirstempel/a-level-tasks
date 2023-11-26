namespace Lesson9.Exceptions;

public class ShoeNotFoundException : Exception
{
    public ShoeNotFoundException(string message) : base(message)
    {
    }

    public ShoeNotFoundException()
    {
    }
}