using System;
using System.Threading.Tasks;

namespace MessageBox;

public static class Program
{
    public static async Task Main()
    {
        MessageBox messageBox = new MessageBox();

        messageBox.OnClose += state =>
        {
            if (state == State.Ok)
            {
                Console.WriteLine("the operation has been confirmed");
                return;
            }
            
            Console.WriteLine("the operation was rejected");
        };

        await messageBox.Open();
    }
}