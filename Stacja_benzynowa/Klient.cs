using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Stacja_benzynowa
{
    public abstract class Klient : IComparable<Klient>
    {
        public string imie;
        public string nazwisko;
        double liczbaKilometrow;
        double stawkazalitr;

        public Klient(string im, string nz, double lk, double st)
        {
            imie = im;
            nazwisko = nz;
            liczbaKilometrow = lk;
            stawkazalitr = st;
        }

        protected virtual double ObliczCalaWplata()
        {
            return liczbaKilometrow * stawkazalitr;
        }

        protected abstract double ObliczPremie();
        

        // Implementacja interfejsu IComparable
        public int CompareTo(Klient obj)
        {
            int rezultat = nazwisko.CompareTo(obj.nazwisko);
            if (rezultat == 0)
                rezultat = imie.CompareTo(obj.imie);
            return rezultat;
        }

        public static string NaglowkiKolumn(Dzial dzial)
        {
    
            return String.Format("{0,-10}{1,15}{2,14}{3,12}{4,16}{5,14}",
              "Imię", "Nazwisko", "Liczba kil.", "St. za ltr", "Cala wplata(zl)", "Premia (pkt)");
        }
        public override string ToString()
        {
            return String.Format("{0,-10}{1,15}{2,14:F2}{3,12:F2}{4,16:F2}{5,14}",
                imie, nazwisko, liczbaKilometrow, stawkazalitr,
                ObliczCalaWplata(), ObliczPremie());
        }
        public virtual string TekstDoPliku()
        {
            return String.Format("{0};{1};{2};{3};{4};{5}",
                imie, nazwisko, liczbaKilometrow, stawkazalitr,
                ObliczCalaWplata(), ObliczPremie());
        }
    }
}
