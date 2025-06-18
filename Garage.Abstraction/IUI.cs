using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage.Abstraction;

public interface IUI
{
    string GetInput();
    uint GetInputUint();
    void Print(string message);
    void Print();
}
