using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Heritage.Entities
{
    public abstract class Forme
    {
        private double aire;
        private double perimetre;

        public abstract double Aire { get ; set; }
        public abstract double Perimetre { get; set; }

        public override string ToString()
        {
            return String.Format("Aire = {0} {1}Périmètre = {2} {1}", this.Aire, Environment.NewLine, this.Perimetre);
        }
    }
}
