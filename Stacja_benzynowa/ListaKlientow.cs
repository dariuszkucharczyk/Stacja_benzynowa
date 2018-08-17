using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Stacja_benzynowa
{
    public class ListaKlientow
    {
        List<Klient> listaOsob;
        Dzial dzial;

        public ListaKlientow(Dzial dz)
        {
            dzial = dz;
            listaOsob = new List<Klient>();
        }

        // Wyświetlenie listy na ekranie
        public bool PokazListe()
        {
            Console.WriteLine(Klient.NaglowkiKolumn(dzial));
            listaOsob.Sort();
            foreach (Klient prac in listaOsob)
            {
                Console.WriteLine(prac.ToString());
            }
            Console.WriteLine();
            Console.WriteLine("Dowolny klawisz - zapisz obliczone premie, Esc - wyjdź bez zapisu");
            ConsoleKeyInfo klawisz = Console.ReadKey(true);
            return (klawisz.Key != ConsoleKey.Escape);
        }

        private bool poprawneDane(string[] tab)
        {
            bool daneSaPoprawne = false;
            double tmp;
            if (tab.Length == 4 && double.TryParse(tab[2], out tmp) &&
                double.TryParse(tab[3], out tmp))
                daneSaPoprawne = true;
            return daneSaPoprawne;
        }

        // Zapisanie do pliku listy pracowników
        public void Zapisz(string sciezka)
        {
            StreamWriter sw = null;
            FileStream fs = null;
            try
            {
                fs = File.Create(sciezka);
                sw = new StreamWriter(fs);
                foreach (Klient prac in listaOsob)
                {
                    sw.WriteLine(prac.TekstDoPliku());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                }
            }
        }

        // Wczytanie danych z pliku
        public void Wczytaj(string sciezka)
        {
            StreamReader re = null;
            FileStream fs = null;
            try
            {
                if (File.Exists(sciezka))
                {
                    fs = new FileStream(sciezka, FileMode.OpenOrCreate, FileAccess.Read);
                    re = new StreamReader(fs);
                    string linia = null;
                    while ((linia = re.ReadLine()) != null)  // wyswietlenie pliku linia po linii
                    {
                        string[] tab = linia.Split(';');
                        if (poprawneDane(tab))
                        {
                            if (dzial == Dzial.kierowcysam)
                                listaOsob.Add(new KierowcaSam(tab));
                            else if (dzial == Dzial.kierowcytir)
                                listaOsob.Add(new KierowcaTir(tab));
                        }
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (re != null)
                {
                    re.Close();
                }
            }
        }

    }
}
