using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{

    enum Loveshiba { hibas_koordinata, nincs_hiba };

    class Negyedik
    {
        static List<Kacsa> kacsak; //kacsákat tartalmazó lista
        static Random R;
        static int result, x, y; //felhasználó lövésének koordinátái

        public static void Feladat()
        {
            R = new Random();
            kacsak = new List<Kacsa>();
        
            for (int i = 0; i < 10; i++) //kacsák lista feltölése
                kacsak.Add(new Kacsa(R));

            Kor(); //Körök lefuttatása

            Console.ReadKey();
        }

        //Körök lefuttatása
        private static void Kor()
        {
            do
            {
            Console.Clear();

            for (int i = 0; i < kacsak.Count; i++) //kacsák X,Y koordinátáinak kiíratása
            {
                Console.WriteLine(i + 1 + ". kacsa: " + kacsak[i].X + "|" + kacsak[i].Y);
            }

            //célhoz legközelebbi kacsa távolsága
            Console.WriteLine("A legközelebbi kacsa távolsága: " + Math.Round(Min(kacsak), 2));
            Console.WriteLine();
            
            //felhasználó általáli lövés
            if (Loves() == Loveshiba.hibas_koordinata)
                Loves_error();

            if (Ujkor()) return; //vége, ha a kacsák nyertek

            //addig ismétlődik, amíg a játékos nem nyer vagy előtte a kacsák
            } while (!Vege()); 

        }

        private static double Min(List<Kacsa> kacsak) //célhoz legközelebbi kacsa távolsága kiválasztása 
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
        static Loveshiba Loves()
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
                    return Loveshiba.nincs_hiba;
                }
                else
                    return Loveshiba.hibas_koordinata; //Y koordináta átalakítása sikertelen
            }
            else
                return Loveshiba.hibas_koordinata; //X koordináta átalakítása sikertelen
        }

        //felhasználi általáli hibás koordináta megadása lövéshez
        private static void Loves_error()
        {
            Console.Write("Hibás koordináta! Kérem adja meg őket újra.");
            Console.ReadKey();
            Loves();
        }

        //Új kör: léptetés, lövés, kacsa halál, kacsa győzelem
        private static bool Ujkor()
        {
            bool vege = false;

            for (int i = 0; i < kacsak.Count; i++)
            {
                kacsak[i].Lep(R); //kacsák léptetése

                if (kacsak[i].X == 5 && kacsak[i].Y == 10) //kacsa elért a célba
                {
                    Console.Write("Játék vége, a kacsák nyertek :(");
                    vege = true;
                    break;
                }
                else if (kacsak[i].X == x && kacsak[i].Y == y) //kacsa nincs még a célban
                {
                    kacsak.RemoveAt(i); //kacsa kilövése, ha a felhasználó eltalálta
                }
            }
            return vege;
        }

        //játékos nyert
        static bool Vege()
        {
            if (kacsak.Count == 0) //minden kacsát kilőtt a játékos
            {
                Console.Write("Játék vége, Ön nyert :)");
                return true;
            }
            return false;
        }
    }
}
