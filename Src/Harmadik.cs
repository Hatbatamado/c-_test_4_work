using System;

namespace test
{
    public enum beolvas_error { NEM_OT,
                                HIBAS_SZAM,
                                TOBB_MINT_OT,
                                NINCS_HIBA };

    class Harmadik
    {
        static int[] szamok = new int[5]; //beolvasott számok tömbje
        static int result; //átkonvertált beolvasott érték

        public static void Feladat()
        {
            beolvas_error hiba = Beolvasas(); //adatok beolvasása és az olvasás közbeni hiba ellenőrzés
            
            if (hiba != beolvas_error.NINCS_HIBA) //hiba lekezelése
                Beolvas_hiba(hiba);
            else
            {
                Rendezes(szamok.Length, szamok); //javított beillesztéses módszerrel rendezve a tömb
                
                Console.WriteLine();

                UjSzamKereses(); //új szám megadása, majd megkeresése a tömbben
            }

            Console.ReadKey();
        }

        //új szám megadása, majd megkeresése a tömbben
        private static void UjSzamKereses()
        {
            do
            {
                Console.Write("Kérek egy újabb számot: ");
            }
            while (!(int.TryParse(Console.ReadLine(), out result))); //addig fut, amíg át nem tudja konvertálni

            //szamok tömb, a tömb min elem száma, a tömb max elem száma, keresendő szám
            if (Kereses(szamok, 0, szamok.Length - 1, result))
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
            if (seged.Length == 5) //5db beolvasott esetén
            {
                for (int i = 0; i < seged.Length; i++)
                {
                    if (int.TryParse(seged[i], out result)) //megpróbáljuk átalakítani
                        szamok[i] = result;
                    else
                        return beolvas_error.HIBAS_SZAM; //sikertelen álalakítás
                }
                return beolvas_error.NINCS_HIBA;
            }
            else if (seged.Length < 5) //megnézzük, hogy a felosztás után tényleg 5 szám van-e
                return beolvas_error.NEM_OT;
            else
                return beolvas_error.TOBB_MINT_OT; //több, mint 5 számot kaptunk beolvasásnál
        }

        //beolvasás közben történt hiba esetek kezelése
        private static void Beolvas_hiba(beolvas_error error)
        {
            switch (error)
            {
                case beolvas_error.HIBAS_SZAM:
                    Console.WriteLine("Hibás számot adott meg!");
                    break;
                case beolvas_error.NEM_OT:
                    Console.WriteLine("Nem 5 számot adott meg!");
                    break;
                case beolvas_error.TOBB_MINT_OT:
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

            //rendezés után kiíratjuk a képernyőre a tömb elemeit
            Console.Write("A bekért számok rendezve:");
            for (int i = 0; i < szamok.Length; i++)
                Console.Write(" " + szamok[i]);
        }

        //rekurzív bináris / logaritmikus keresés
        //vizsgálandó tömb, kezdő index, utolsó index, keresendő érték
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
