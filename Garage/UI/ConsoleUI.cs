using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using Garage.Abstraction;

namespace Garage.UI;

internal class ConsoleUI : IUI
{
    public void Print(string message)
    {
        Console.WriteLine(message);
    }

    public void Print()
    {
        Console.WriteLine();
    }

    public string GetInput()
    {
        return Console.ReadLine() ?? string.Empty;
    }

    public uint GetInputUint()
    {
        string input = GetInput();

        if (!uint.TryParse(input, out uint result))
            throw new ArgumentException($"{input} is not a valid positive number.");

        return result;
    }

}
