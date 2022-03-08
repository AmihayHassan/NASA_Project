using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace NASA_BE
{
    //TODO: not in use, need to delete
    public class Asteroid : IAstronomicalObject
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Discovered { get; set; }
        public double Aphelion { get; set; } // max distance from sun
        public double Perihelion { get; set; } // min distance from sun
        public double OrbitalPeriod { get; set; }
        public double AverageSpeed { get; set; }
        public Dictionary<string, double> MaterialsDict { get; set; }

    }
}
