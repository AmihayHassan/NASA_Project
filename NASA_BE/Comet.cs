using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_BE
{
    public class Comet : IAstronomicalObject
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public DateTime Discovered { get; set; }
        public double Aphelion { get; set; } // max distance from sun
        public double Perihelion { get; set; } // min distance from sun
        public double OrbitalPeriod { get; set; }
        public double AverageSpeed { get; set; }
        public List<string> MaterialsList { get; set; }
        public double OrbitalInclination { get; set; } // angle between 2 planes
    }
}
