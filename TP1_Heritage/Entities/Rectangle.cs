using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Heritage.Entities
{
    public class Rectangle : Forme
    {
        private double longueur = 0;
        private double largeur = 0;

        public double Longueur { get => longueur; set => longueur = value; }
        public double Largeur { get => largeur; set => largeur = value; }
        public override double Aire { get => Longueur * Largeur; }
        public override double Perimetre { get => (Longueur + Largeur) * 2; }


        public override string ToString()
        {
            return  String.Format("Rectangle de longueur = {0} et largeur = {1} {2}",
                this.Longueur, this.Largeur, Environment.NewLine) + base.ToString();
        }
    }
}

