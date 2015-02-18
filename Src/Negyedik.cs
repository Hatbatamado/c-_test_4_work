using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Negyedik
    {
        static List<Kacsa> kacsak;
        static Random R;
        static public void Feladat()
        {
            R = new Random();
            kacsak = new List<Kacsa>();
            for (int i = 0; i < 10; i++)
                kacsak.Add(new Kacsa(R));

            Kor();

            Console.ReadKey();
        }

        static void Kor()
        {
            do
            {
            Console.Clear();

            for (int i = 0; i < kacsak.Count; i++)
            {
                Console.WriteLine(i + 1 + ". kacsa: " + kacsak[i].X + "|" + kacsak[i].Y);
            }

            Console.WriteLine("A legközelebbi kacsa távolsága: " + Math.Round(Min(kacsak), 2));
            Console.WriteLine();
            
            Loves();

            if (Ujkor()) return;
            } while (!Vege());

        }

        static private double Min(List<Kacsa> kacsak)
        {
            int min = 0;
            for (int i = 1; i < kacsak.Count; i++)
            {
                if (kacsak[i].Tavolsag() < kacsak[min].Tavolsag())
                    min = i;
            }

            return kacsak[min].Tavolsag();
        }

        static int result, x, y;
        static bool hiba;
        static void Loves()
        {
            hiba = false;
            Console.Write("A lövés koordinátája vesszővel elválasztva (pl.: 4,5): ");
            string[] seged = Console.ReadLine().Split(',');
            if (seged.Length == 2)
            {
                if (int.TryParse(seged[0], out result))
                {
                    x = result;
                    if (int.TryParse(seged[1], out result))
                        y = result;
                    else
                    {
                        Console.Write("Hibás koordináta");
                        hiba = true;
                    }
                }
                else
                {
                    Console.Write("Hibás koordináta");
                    hiba = true;
                }
            }
            else
            {
                Console.Write("Hibás koordináta");
                hiba = true;
            }

            if (hiba)
            {
                Console.ReadKey();
                Loves();
            }
        }

        static bool Ujkor()
        {
            int talalt = 0;
            bool vege = false;

            for (int i = 0; i < kacsak.Count; i++)
            {
                kacsak[i].Lep(R);
                if (kacsak[i].X == 5 && kacsak[i].Y == 10)
                {
                    Console.Write("Játék vége, a kacsák nyertek :(");
                    vege = true;
                    break;
                }
                else if (kacsak[i].X == x && kacsak[i].Y == y)
                {
                    kacsak.RemoveAt(i);
                    talalt++;
                }
            }
            return vege;
        }

        static bool Vege()
        {
            if (kacsak.Count == 0)
            {
                Console.Write("Játék vége, Ön nyert :)");
                return true;
            }
            return false;
        }
    }
}
