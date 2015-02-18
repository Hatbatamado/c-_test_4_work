using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Harmadik
    {
        static public void Feladat()
        {
            string beolvas;
            int[] szamok = new int[5];
            bool hiba = false;
            int result;

            Console.Clear();
            Console.Write("Adjon meg 5 számot szóközzel elválasztva: ");
            beolvas = Console.ReadLine();

            string[] seged = beolvas.Split(' ');
            if (seged.Length < 5)
            {
                Console.WriteLine("Nem 5 számot adott meg!");
                hiba = true;
            }
            else if (seged.Length == 5)
            {
                for (int i = 0; i < seged.Length; i++)
                {
                    if (int.TryParse(seged[i], out result))
                        szamok[i] = result;
                    else
                    {
                        Console.WriteLine("Hibás számot adott meg!");
                        hiba = true;
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Több, mint 5 számot adott meg!");
                hiba = true;
            }

            if (hiba)
            {
                Console.Write("Kérem adja meg a számokat újból az ENTER megnyomása után!");
                Console.ReadLine();
                Harmadik.Feladat();
            }

            Rendezes(szamok.Length, szamok);

            Console.Write("A bekért számok rendezve:");
            for (int i = 0; i < szamok.Length; i++)
            {
                Console.Write(" " + szamok[i]);
            }
            Console.WriteLine();

            do
            {
                Console.Write("Kérek egy újabb számot: ");
            }
            while (!(int.TryParse(Console.ReadLine(), out result)));

            if (Kereses(szamok, 0, szamok.Length - 1, result))
                Console.Write("A szám megtalálható az előbb megadott sorozatban.");
            else
                Console.Write("A szám nem található meg az előbb megadott sorozatban.");

            Console.ReadKey();
        }

        static private void Rendezes(int N, int[] X)
        {
            int j;
            int Y;
            for (int i = 2; i < N; i++)
            {
                j = i - 1;
                Y = X[i];
                while (j > 0 && X[j] > Y)
                {
                    X[j + 1] = X[j];
                    j--;
                }
                X[j + 1] = Y;
            }
        }

        static private bool Kereses(int[] tomb, int E, int U, int Y)
        {
            int K;

            if (E > U)
                return false;
            else
            {
                K = (E + U) / 2;
                if (tomb[K] == Y)
                    return true;
                else if (tomb[K] < Y)
                    return (Kereses(tomb, K + 1, U, Y));
                else
                    return (Kereses(tomb, E, K - 1, Y));
            }
        }

    }
}
