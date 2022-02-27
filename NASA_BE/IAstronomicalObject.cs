using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_BE
{
    public interface IAstronomicalObject : IRecord// TODO check if better as abstract class
    {
        string Name { get; set; }
        double Aphelion { get; set; } // max distance from sun
        double Perihelion { get; set; } // min distance from sun
        double OrbitalPeriod { get; set; }
        double AverageSpeed { get; set; }
        //Dictionary<string, double> MaterialsDict { get; set; }
    }
}
