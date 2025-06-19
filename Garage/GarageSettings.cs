using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Garage;

internal interface IGarageSettings
{
    int Capacity { get; set; }
}

internal class GarageSettings : IGarageSettings
{
    public int Capacity { get; set; }
}
