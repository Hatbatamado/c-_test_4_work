using System;

namespace test
{
    class Elso
    {
        const int minprim = 2;

        public static void Feladat()
        {
            int result; //megadott szám konvertált értéke
            bool siker; //megadott szám konvertálása sikeres-e
            do
            {
                Console.Clear();
                Console.Write("Adjon meg egy pozitív egész számot: ");
                siker = int.TryParse(Console.ReadLine(), out result);
            }//csak akkor fusson tovább, ha pozitív és ha sikerült konvertálni
            while (!siker || result < 0);

            if (Prim(result))
                Console.Write("A megadott szám prím szám");
            else
                Console.Write("A megadott szám nem prím szám");

            Console.ReadKey();
        }

        //megmondja a paraméterben átadott számról, hogy prím-e, ha igen true-val tér vissza
        private static bool Prim(int szam)
        {
            if (szam < minprim) //2-től vannak a prím számok
                return false;

            int gyok = (int)Math.Sqrt(szam); //sorozat gyökéig kell nézni
            bool vanOszto = false;

            for (int i = 1; i <= gyok; i++) //osztó db sztámok keresése
            {
                if (szam % i == 0)
                {
                    //már van osztója ezen kívül, tuti nem prím
                    if (vanOszto)
                        return false;
                    vanOszto = true;
                }
            }
            return true;
        }
    }
}
