using DelegatesApp.Delegates;

namespace DelegatesApp.Abstractions;

public interface IClass2
{
    Result Calc(Operation multiply, int x, int y);
    bool Result(int x);
}