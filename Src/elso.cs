using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Elso
    {
        static public void Feladat()
        {
            int result; //megadott szám konvertált értéke
            do
            {
                Console.Clear();
                Console.Write("Adjon meg egy pozitív egész számot: ");
            }//csak akkor fusson tovább, ha pozitív és ha sikerült konvertálni
            while (!int.TryParse(Console.ReadLine(), out result) || result < 0);

            if (result >= 2) //2-től vannak a prím számok
            {
                int gyok = (int)Math.Sqrt(result); //sorozat gyökéig kell nézni
                int db = 0;

                for (int i = 1; i <= gyok; i++) //osztó db sztámok keresése
                    if (result % i == 0)
                        db++;

                if (db == 1) //osztó db szám alapján prím-e
                    Console.Write("A megadott szám prím szám");
                else
                    Console.Write("A megadott szám nem prím szám");
            }
            else
                Console.Write("A megadott szám nem prím szám");


            Console.ReadKey();
        }
    }
}
