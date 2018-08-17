using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace Stacja_benzynowa
{
    static class Menu
    {
        static string sciezkaDaneKierowcySam = @"..\..\DANE\DaneKierowcySam.txt";
        static string sciezkaDaneKierowcyTir = @"..\..\DANE\DaneKierowcyTir.txt";
        static string sciezkaWynikiKierowcySam = @"..\..\DANE\WynikiKierowcySam.txt";
        static string sciezkaWynikiKierowcyTir = @"..\..\DANE\WynikiKierowcyTir.txt";

        public static void StartMenu()
        {
            Console.Title = "Klienci Stacji benzynowej Bp";
           
            Console.SetWindowSize(80, 30);

            while (true)
            {
                int wiersz = 5, kolumna = 20;
                Console.Clear();
                Console.CursorVisible = false;
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.SetCursorPosition(20, 1);
                Console.Write("Klienci Stacji benzynowej Bp");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.SetCursorPosition(kolumna, wiersz++);
                Console.Write("1 - Wczytaj i oblicz premię kierowców samochodów");
                Console.SetCursorPosition(kolumna, wiersz++);
                Console.Write("2 - Wczytaj i oblicz premię kierowców tira");
                Console.SetCursorPosition(kolumna, wiersz++);
                Console.Write("3 - Wyjście");
                Console.ForegroundColor = ConsoleColor.White;
                ConsoleKeyInfo klawisz = Console.ReadKey(true);
                switch (klawisz.Key)
                {
                    case ConsoleKey.D1:
                        Console.Clear();
                        WczytajKierowcowSam();
                        break;
                    case ConsoleKey.D2:
                        Console.Clear();
                        WczytajKierowcowTir();
                        break;
                    case ConsoleKey.Escape:
                    case ConsoleKey.D3:
                        Console.Clear();
                        return;
                    default:
                        break;
                }
            }
        }
        static void WczytajKierowcowSam()
        {
            ListaKlientow kierowcysam = new ListaKlientow(Dzial.kierowcysam);
            kierowcysam.Wczytaj(sciezkaDaneKierowcySam);
            if (kierowcysam.PokazListe())
            {
                kierowcysam.Zapisz(sciezkaWynikiKierowcySam);
            }
        }

        static void WczytajKierowcowTir()
        {
            ListaKlientow kierowcytir = new ListaKlientow(Dzial.kierowcytir);
            kierowcytir.Wczytaj(sciezkaDaneKierowcyTir);
            if (kierowcytir.PokazListe())
            {
                kierowcytir.Zapisz(sciezkaWynikiKierowcyTir);
            }
        }
    }
}
