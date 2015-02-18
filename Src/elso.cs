using System;

namespace test
{
    class Elso
    {
        public static void Feladat()
        {
            int result; //megadott szám konvertált értéke
            do
            {
                Console.Clear();
                Console.Write("Adjon meg egy pozitív egész számot: ");
            }//csak akkor fusson tovább, ha pozitív és ha sikerült konvertálni
            while (!int.TryParse(Console.ReadLine(), out result) || result < 0);

            if (Prim(result))
                Console.Write("A megadott szám prím szám");
            else
                Console.Write("A megadott szám nem prím szám");

        }

        private static bool Prim(int szam)
        {
            if (szam >= 2) //2-től vannak a prím számok
            {
                int gyok = (int)Math.Sqrt(szam); //sorozat gyökéig kell nézni
                int db = 0;

                for (int i = 1; i <= gyok; i++) //osztó db sztámok keresése
                    if (szam % i == 0)
                        db++;

                if (db == 1) //osztó db szám alapján prím-e
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
