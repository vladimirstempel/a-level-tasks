using DelegatesApp.Abstractions;

namespace DelegatesApp;

public sealed class Class1 : IClass1
{
    public delegate void Show(bool show);

    public int Multiply(int x, int y)
    {
        return x * y;
    }
}