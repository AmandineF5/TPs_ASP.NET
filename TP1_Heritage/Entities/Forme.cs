using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Heritage.Entities
{
    public abstract class Forme
    {

        public abstract double Aire { get; }
        public abstract double Perimetre { get; }

        public override string ToString()
        {
            return String.Format("Aire = {0} {1}Périmètre = {2} {1}", this.Aire, Environment.NewLine, this.Perimetre);
        }
    }
}
