namespace ElectricalAppliances.Exceptions;

public class MaxAppliancesException : Exception
{
    public MaxAppliancesException()
    {
    }

    public MaxAppliancesException(string message) : base(message)
    {
    }
}