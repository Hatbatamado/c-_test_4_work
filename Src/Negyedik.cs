using System;
using System.Collections.Generic;

namespace test
{

    public enum Loveshiba { hibas_koordinata, 
                            nincs_hiba,
                            csalas };

    class Negyedik
    {
        private static List<Kacsa> kacsak; //kacsákat tartalmazó lista
        private static int result, x, y; //felhasználó lövésének koordinátái

        public static void Feladat()
        {
            kacsak = new List<Kacsa>();
        
            for (int i = 0; i < 10; i++) //kacsák lista feltölése
                kacsak.Add(new Kacsa());
            
            Kor(); //Körök lefuttatása

            Console.ReadKey();
        }

        //Körök lefuttatása
        private static void Kor()
        {
            Loveshiba hiba; //felhasználi általi hibákhoz, csaláshoz

            do
            {
                Kiiras(); //kacsák koordinátái és a célhoz legközelebbi kacsa távolsága kiírása

                //felhasználó általáli lövés
                hiba = Loves();
                if (hiba != Loveshiba.nincs_hiba)
                    Loves_error(hiba);

                if (Ujkor()) return; //Új kör: léptetés, lövés, kacsa halál, kacsa győzelem

                //addig ismétlődik, amíg a játékos nem nyer vagy előtte a kacsák
            } while (!Vege());
        }

        //kacsák koordinátái és a célhoz legközelebbi kacsa távolsága kiírása
        private static void Kiiras() 
        {
            Console.Clear();

            for (int i = 0; i < kacsak.Count; i++) //kacsák X,Y koordinátáinak kiíratása
            {
                Console.WriteLine(i + 1 + ". kacsa: " + kacsak[i].X + "|" + kacsak[i].Y);
            }

            //célhoz legközelebbi kacsa távolsága
            Console.WriteLine("A legközelebbi kacsa távolsága: " + Math.Round(Min(kacsak), 2));
            Console.WriteLine();
        }

        //célhoz legközelebbi kacsa távolsága kiválasztása 
        private static double Min(List<Kacsa> kacsak) 
        {
            int min = 0;
            for (int i = 1; i < kacsak.Count; i++)
            {
                if (kacsak[i].Tavolsag() < kacsak[min].Tavolsag())
                    min = i;
            }

            return kacsak[min].Tavolsag();
        }

        //felhasználó általáli lövés
        private static Loveshiba Loves()
        {
            Console.Write("A lövés koordinátája vesszővel elválasztva (pl.: 4,5): ");
            string[] seged = Console.ReadLine().Split(',');
            if (seged.Length != 2)
                return Loveshiba.hibas_koordinata;

            if (int.TryParse(seged[0], out result)) //X koordináta átalakítása
            {
                x = result;
                if (int.TryParse(seged[1], out result)) //Y koordináta átalakítása
                {
                    y = result;
                    
                    if (x == 5 && y == 10)
                        return Loveshiba.csalas; //csalni akar a játékos
                    else
                        return Loveshiba.nincs_hiba; //sikerült az átalakítás és csalás sincs
                }
                else
                    return Loveshiba.hibas_koordinata; //Y koordináta átalakítása sikertelen
            }
            else
                return Loveshiba.hibas_koordinata; //X koordináta átalakítása sikertelen
        }

        //felhasználi általáli hibás koordináta megadása lövéshez, csalás
        private static void Loves_error(Loveshiba hiba)
        {
            Console.WriteLine(); //1 sor eltolás, hogy a felhasználó jobban észrevegye mi a hiba
            if (hiba == Loveshiba.hibas_koordinata)
                Console.WriteLine("Hibás koordináta! Kérem adja meg őket újra.");
            else if (hiba == Loveshiba.csalas)
                Console.WriteLine("Nem csalunk! Nem lövünk a célra!"+
                    "\nAdjon meg új célpontot a lövésnek.");
            Loves();
        }

        //Új kör: léptetés, lövés, kacsa halál, kacsa győzelem
        private static bool Ujkor()
        {
            bool kacsaGyozelem = false;
            for (int i = 0; i < kacsak.Count; i++)
            {
                kacsak[i].Lep(); //kacsák léptetése

                if (kacsak[i].X == 5 && kacsak[i].Y == 10) //kacsa elért a célba
                {
                    Kiiras();
                    Console.WriteLine();
                    Console.WriteLine("Játék vége, a kacsák nyertek :("+
                        "\nA(z) " + (i + 1) + ". kacsa beért a célba");
                    kacsaGyozelem = true;
                    break;
                }
                else if (kacsak[i].X == x && kacsak[i].Y == y) //kacsa nincs még a célban
                {
                    kacsak.RemoveAt(i); //kacsa kilövése, ha a felhasználó eltalálta
                }
            }
            return kacsaGyozelem;
        }

        //játékos nyert
        private static bool Vege()
        {
            if (kacsak.Count == 0) //minden kacsát kilőtt a játékos
            {
                Console.Write("Kilőtte az utolsó kacsát is!"+
                    "\nJáték vége, Ön nyert :)");
                return true;
            }
            else
                return false;
        }
    }
}
