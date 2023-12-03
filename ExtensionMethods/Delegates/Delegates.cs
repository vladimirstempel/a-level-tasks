namespace ExtensionMethods;

public delegate int Operation(int x, int y);

internal static class Delegates
{
    public static int Sum(int x, int y)
    {
        return x + y;
    }
}