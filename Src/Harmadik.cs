using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    enum beolvas_error { nem_öt, hibás_szám, több_mint_öt, nincs_hiba };
    class Harmadik
    {
        static int[] szamok = new int[5]; //beolvasott számok tömbje
        static int result; //átkonvertált beolvasott érték

        static public void Feladat()
        {
            beolvas_error hiba = Beolvasas();
            
            if (hiba != beolvas_error.nincs_hiba)
                Beolvas_hiba(hiba);
            else
            {
                Rendezes(szamok.Length, szamok); //javított beillesztéses módszerrel rendezve a tömb
                
                Console.WriteLine();

                Uj_szam_kereses(); //új szám megadása, majd megkeresése a tömbben
            }

            Console.ReadKey();
        }

        //új szám megadása, majd megkeresése a tömbben
        private static void Uj_szam_kereses()
        {
            do
            {
                Console.Write("Kérek egy újabb számot: ");
            }
            while (!(int.TryParse(Console.ReadLine(), out result))); //addig fut, amíg át nem tudja konvertálni

            if (Kereses(szamok, 0, szamok.Length - 1, result))
                //szamok tömbben, tömb min elem száma, tömb max elem száma, keresendő szám
                Console.Write("A szám megtalálható az előbb megadott sorozatban.");
            else
                Console.Write("A szám nem található meg az előbb megadott sorozatban.");
        }

        //beolvassuk a konzolról a szám adatokat
        private static beolvas_error Beolvasas()
        {
            
            string beolvas; //beolvasott szöveg sorozat

            Console.Clear();
            Console.Write("Adjon meg 5 számot szóközzel elválasztva: ");
            beolvas = Console.ReadLine();

            string[] seged = beolvas.Split(' '); //beolvasott sorozat felosztása szóköz alapján
            if (seged.Length < 5) //megnézzük, hogy a felosztás után tényleg 5 szám van-e
                return beolvas_error.nem_öt;
            else if (seged.Length == 5) //5db beolvasott esetén
            {
                for (int i = 0; i < seged.Length; i++)
                {
                    if (int.TryParse(seged[i], out result)) //megpróbáljuk átalakítani
                        szamok[i] = result;
                    else
                        return beolvas_error.hibás_szám;
                }
                return beolvas_error.nincs_hiba;
            }
            else
                return beolvas_error.több_mint_öt; //több, mint 5 számot kaptunk beolvasásnál
        }

        //beolvasás közben történt hiba esetek
        private static void Beolvas_hiba(beolvas_error error)
        {
            switch (error)
            {
                case beolvas_error.hibás_szám:
                    Console.WriteLine("Hibás számot adott meg!");
                    break;
                case beolvas_error.nem_öt:
                    Console.WriteLine("Nem 5 számot adott meg!");
                    break;
                case beolvas_error.több_mint_öt:
                    Console.WriteLine("Több, mint 5 számot adott meg!");
                    break;
            }
            
            Console.Write("Kérem adja meg a számokat újból az ENTER megnyomása után!");
            Console.ReadLine();
            Harmadik.Feladat();
        }

        //javított beillesztéses módszerrel rendezzük a tömböt
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
            
            Console.Write("A bekért számok rendezve:");
            //rendezés után kiíratjuk a képernyőre a tömb elemeit
            for (int i = 0; i < szamok.Length; i++)
                Console.Write(" " + szamok[i]);
        }

        //rekurzív bináris / logaritmikus keresés
        static private bool Kereses(int[] tomb, int E, int U, int Y)
        { //vizsgálandó tömb, kezdő index, utolsó index, keresendő értékk
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
