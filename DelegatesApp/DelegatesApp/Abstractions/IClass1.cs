namespace DelegatesApp.Abstractions;

public interface IClass1
{
    public delegate void Show(bool show);

    public int Multiply(int x, int y);
}