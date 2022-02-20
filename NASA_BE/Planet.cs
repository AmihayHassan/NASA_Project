﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NASA_BE
{
    public class Planet : IAstronomicalObject
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public double AverageDistanceFromTheSun { get; set; }
        public double Aphelion { get; set; } // max distance from sun
        public double Perihelion { get; set; } // min distance from sun
        public double Radius { get; set; }
        public double Mass { get; set; }
        public double SurfaceTemp { get; set; }
        public double OrbitalPeriod { get; set; }
        public double AverageSpeed { get; set; }
        public double RotationPeriod { get; set; }
        public int MoonNumber { get; set; }
        public double AtmosphericPressure { get; set; }
        public List<string> MaterialsList { get; set; }

    }
}
