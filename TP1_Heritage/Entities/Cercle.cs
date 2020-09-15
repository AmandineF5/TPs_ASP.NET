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

        public override double Aire { get => (Rayon * Rayon) * Math.PI;}
        public override double Perimetre { get => 2 * Rayon * Math.PI;}
        public double Rayon { get => Rayon; set => Rayon = value; }


        public override string ToString()
        {
            return String.Format("Cercle de rayon {0} {1}", 
                this.Rayon, Environment.NewLine) + base.ToString();
        }

    }
}
