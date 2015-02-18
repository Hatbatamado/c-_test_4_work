using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Masodik
    {
        static public void Feladat()
        {
            const int fibodb = 5;
            int[] fibo = new int[fibodb];

            Console.Clear();
            Console.Write("A(z) " + fibodb + " db fibonacci szám:");
            for (int i = 0; i < fibo.Length; i++)
            {
                fibo[i] = Fib(i);
                Console.Write(" " + fibo[i]);
            }
            
            Console.ReadKey();
        }

        static private int Fib(int N)
        {
            if (N <= 1)
                return N;
            else
                return (Fib(N - 1) + Fib(N - 2));
        }
    }
}
