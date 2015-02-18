using System;

namespace test
{
    class Masodik
    {
        public static void Feladat()
        {
            Fibonacci();
            
            Console.ReadKey();
        }

        private static void Fibonacci()
        {
            const int fibodb = 5; //Fibonacci sorozat elemeinek száma
            int[] fibo = new int[fibodb]; //Fibonacci számokat tartalmazó tömb

            Console.Clear();
            Console.Write("A(z) " + fibodb + " db fibonacci szám:");
            for (int i = 0; i < fibo.Length; i++)
            {
                fibo[i] = Fib(i); //Fibonacci-s tömb feltöltése
                Console.Write(" " + fibo[i]); //konzolra kiíratás
            }
        }

        private static int Fib(int N) //N-edik Fibonacci szám
        {
            if (N <= 1)
                return N;
            else
                return (Fib(N - 1) + Fib(N - 2));
        }
    }
}
