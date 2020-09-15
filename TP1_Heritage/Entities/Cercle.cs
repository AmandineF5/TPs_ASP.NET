using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Heritage.Entities
{
    class Cercle : Forme
    {
        private double rayon = 0;
        private double aire = 0;
        private double perimetre = 0;

        public override double Aire { get => (rayon * rayon) * Math.PI;}
        public override double Perimetre { get => 2 * rayon * Math.PI;}
        public double Rayon { get => rayon; set => rayon = value; }


        public override string ToString()
        {
            return String.Format("Cercle de rayon {0} {1}", 
                this.Rayon, Environment.NewLine) + base.ToString();
        }

    }
}
