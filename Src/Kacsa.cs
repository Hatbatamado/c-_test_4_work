using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public Kacsa(Random R)
        {
            x = R.Next(0, 6); //véletlen X koordináta 0-5
            y = R.Next(0, 11); //véletlen Y koordináta 0-10
        }

        public void Lep(Random R)
        {
            switch(R.Next(0,3)) //véletlen mozgás balra (0), felfele (1), balra átlósan (2)
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
    }
}
