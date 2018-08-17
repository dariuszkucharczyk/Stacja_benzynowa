using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Stacja_benzynowa
{
    class KierowcaTir :Klient
    {

        public KierowcaTir(string im, string nz, double lk,
                     double st) : base(im, nz, lk, st) { }


        public KierowcaTir(string[] tab) : base(tab[0], tab[1], double.Parse(tab[2]), double.Parse(tab[3])) { }


        protected override double ObliczPremie()
        {
            double procentPremii = 0.50;

            return base.ObliczCalaWplata() * procentPremii;
        }

        public override string ToString()
        {
            return base.ToString();

        }
        public override string TekstDoPliku()
        {
            return base.TekstDoPliku();

        }
    }
}
