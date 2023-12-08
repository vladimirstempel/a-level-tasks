using System;
using System.Threading.Tasks;

namespace MessageBox;

public sealed class MessageBox
{
    private const int Delay = 3000;

    public event Action<State> OnClose;
    
    public async Task Open()
    {
        Console.WriteLine("window is open");
        
        await Task.Delay(Delay);
        
        Console.WriteLine("window was closed by the user");
        
        OnClose?.Invoke(RandomState());
    }

    private State RandomState()
    {
        var values = Enum.GetValues(typeof(State));
        var random = new Random();
        return (State)values.GetValue(random.Next(values.Length))!;
    }
}