namespace ExtensionMethods;

internal delegate int Operation(int x, int y);

internal static class Subscriptions
{
    public static int Sum(int x, int y)
    {
        return x + y;
    }
}