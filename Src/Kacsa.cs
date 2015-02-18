using System;

namespace test
{
    class Kacsa
    {
        int x; //kacsa X koordináta: 0..5

        public int X
        {
            get { return x; }
        }
        int y; //kacsa Y koordináta: 0..10

        public int Y
        {
            get { return y; }
        }

        public Kacsa()
        {
            
            x = VeletlenSzam(0, 5); //véletlen X koordináta 0-5
            y = VeletlenSzam(0, 10); //véletlen Y koordináta 0-10
            Lep(); //véletlen mozgás balra, felfele, balra átlósan
        }

        public void Lep()
        {
            switch (VeletlenSzam(0, 3)) //véletlen mozgás balra (0), felfele (1), balra átlósan (2)
            {
                case 0: //véletlen mozgás balra (0)
                    if ((x + 1) <= 5) //játéktér szélén megáll a kacsa és már csak 1 irányba tud menni
                        x++;
                    break;
                case 1: //véletlen mozgás felfele (1)
                    if ((y + 1) <= 10) //játéktér szélén megáll a kacsa és már csak 1 irányba tud menni
                        y++;
                    break;
                case 2: //véletlen mozgás balra átlósan (2)
                    if ((x + 1) <= 5 && (y + 1) <= 10) //játéktér szélén megáll a kacsa és már csak 1 irányba tud menni
                    {
                        x++;
                        y++;
                    }
                    break;
            }
        }

        public double Tavolsag() //aktuális pont és a cél közötti távolság kiszámítása
        {
            return Math.Sqrt(Math.Pow(5 - x, 2) + (Math.Pow(10 - y, 2)));
        }

        private int VeletlenSzam(int min, int max) //2 paraméter közötti számok közül visszad egy véletlen számot
        {
            return RandomHelper.GetRandomGenerator.Next(min, max + 1);
        }
    }
}
