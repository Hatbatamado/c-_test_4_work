using System;

namespace test
{
    class Kacsa
    {
        private int x; //kacsa X koordináta: 0..5

        public int X
        {
            get { return x; }
        }
        private int y; //kacsa Y koordináta: 0..10

        public int Y
        {
            get { return y; }
        }

        public Kacsa()
        {

            x = 0; //minden kacsa a 'földről' indul
            y = VeletlenSzam(0, 10); //véletlen Y koordináta 0-10
            Lep(); //véletlen mozgás balra, felfele, balra átlósan
        }

        //véletlen mozgás balra (1), felfele (2), balra átlósan (0)
        //ha a kacsa eléri a játéktér valamelyik szélét, akkor megpróbál valamerre tovább menni
        public void Lep()
        {
            switch (VeletlenSzam(0, 2)) 
            {
                case 0: //véletlen mozgás balra átlósan (0)
                    if ((x + 1) <= 5 && (y + 1) <= 10)
                    {
                        x++;
                        y++;
                    }
                    else if ((x + 1) > 5) //ha balra már nem tudunk menni, akkor próbáljunk felfele menni
                        goto case 2;
                    else if ((y + 1) > 10) //ha felfele már nem tudunk menni, akkor próbáljunk balra menni
                        goto case 1;
                    break;
                case 1: //véletlen mozgás balra (1)
                    if ((x + 1) <= 5)
                        x++;
                    else
                        goto case 2; //ha balra már nem tudunk menni, akkor próbáljunk felfele menni
                    break;
                case 2: //véletlen mozgás felfele (2)
                    if ((y + 1) <= 10)
                        y++;
                    else
                        goto case 1; //ha felfele már nem tudunk menni, akkor próbáljunk balra menni
                    break;                
            }
        }

        //aktuális pont és a cél közötti távolság kiszámítása
        public double Tavolsag()
        {
            return Math.Sqrt(Math.Pow(5 - x, 2) + (Math.Pow(10 - y, 2)));
        }

        //2 paraméter által határolt intervallu,ból visszaad egy véletlen számot
        private int VeletlenSzam(int min, int max)
        {
            return RandomHelper.GetRandomGenerator.Next(min, max + 1);
        }
    }
}
