using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Elso
    {
        static public void Feladat()
        {
            int result;

            do
            {
                Console.Clear();
                Console.Write("Adjon meg egy pozitív egész számot: ");
            }
            while (!(int.TryParse(Console.ReadLine(), out result)));

            if (result >= 2)
            {
                int gyok = (int)Math.Sqrt(result);
                int db = 0;

                for (int i = 1; i <= gyok; i++)
                    if (result % i == 0)
                        db++;

                if (db == 1)
                    Console.Write("A megadott szám prím szám");
                else
                    Console.Write("A megadott szám nem prím szám");
            }
            else
                Console.Write("A megadott szám nem prím szám");


            Console.ReadKey();
        }
    }
}
