using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1_Heritage.Entities
{
    public class Triangle : Forme
    {
        private double a = 0;
        private double b = 0;
        private double c = 0;
        private double aire = 0;
        private double perimetre = 0;

        public double A { get => a; set => a = value; }
        public double B { get => b; set => b = value; }
        public double C { get => c; set => c = value; }
        public override double Aire { get => (a * b) / 2; }
        public override double Perimetre { get => a + b + c; }

        public override string ToString()
        {
            return String.Format("Triangle de côté A = {0}, B = {1}, C = {2} {3}",
                this.A, this.B, this.C, Environment.NewLine) + base.ToString();
        }
    }
}
