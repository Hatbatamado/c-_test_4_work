using System;

namespace test
{
    class Masodik
    {
        const int fibodb = 5; //Fibonacci sorozat elemeinek száma

        public static void Feladat()
        {
            GetFibonacci(fibodb);
            
            Console.ReadKey();
        }

        private static void GetFibonacci(int hany)
        {
            
            int[] fibo = new int[hany]; //Fibonacci számokat tartalmazó tömb

            Console.Clear();
            Console.Write("A(z) " + hany + " db fibonacci szám:");
            for (int i = 0; i < fibo.Length; i++)
            {
                fibo[i] = RecursiveFibonacci(i); //Fibonacci-s tömb feltöltése
                Console.Write(" " + fibo[i]); //konzolra kiíratás
            }
        }

        private static int RecursiveFibonacci(int N) //N-edik Fibonacci szám
        {
            if (N <= 1)
                return N;
            else
                return (RecursiveFibonacci(N - 1) + RecursiveFibonacci(N - 2));
        }
    }
}
