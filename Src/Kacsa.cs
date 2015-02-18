using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Kacsa
    {
        int x; //0..5

        public int X
        {
            get { return x; }
        }
        int y; //0..10

        public int Y
        {
            get { return y; }
        }

        public Kacsa(Random R)
        {
            x = R.Next(0, 6);
            y = R.Next(0, 11);
        }

        public void Lep(Random R)
        {
            switch(R.Next(0,3))
            {
                case 0:
                    if ((x + 1) <= 5)
                        x++;
                    break;
                case 1:
                    if ((y + 1) <= 10)
                        y++;
                    break;
                case 2:
                    if ((x + 1) <= 5 && (y + 1) <= 10)
                    {
                        x++;
                        y++;
                    }
                    break;
            }
        }

        public double Tavolsag()
        {
            return Math.Sqrt(Math.Pow(5 - x, 2) + (Math.Pow(10 - y, 2)));
        }
    }
}
