using DelegatesApp.Abstractions;
using DelegatesApp.Delegates;

namespace DelegatesApp;

public sealed class Class2 : IClass2
{
    private int _result;
    
    public Result Calc(Operation multiply, int x, int y)
    {
        _result = multiply(x, y);

        return Result;
    }

    public bool Result(int x)
    {
        return _result % x == 0;
    }
}