﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Heritage.Entities
{
    public class Carre : Forme
    {
        private double longueur = 0;

        public double Longueur { get => longueur; set => longueur = value; }
        public override double Aire { get => Longueur * Longueur; }
        public override double Perimetre { get => Longueur * 4; }

        public override string ToString()
        {
            return String.Format("Carré de longueur = {0} {1}", this.Longueur,
                Environment.NewLine) + base.ToString();
        }
    }
}
