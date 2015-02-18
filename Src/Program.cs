using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo key;

            Console.Clear();
            Console.WriteLine("**********Menu**********");
            Console.WriteLine("*                      *");
            Console.WriteLine("*  1. feladat          *");
            Console.WriteLine("*  2. feladat          *");
            Console.WriteLine("*  3. feladat          *");
            Console.WriteLine("*  4. feladat          *");
            Console.WriteLine("*                      *");
            Console.Write("************************");

            key = Console.ReadKey();
            switch(key.Key)
            {
                case ConsoleKey.D1:
                case ConsoleKey.NumPad1:
                    Elso.Feladat();
                    break;
                case ConsoleKey.D2:
                case ConsoleKey.NumPad2:
                    Masodik.Feladat();
                    break;
                case ConsoleKey.D3:
                case ConsoleKey.NumPad3:
                    Harmadik.Feladat();
                    break;
                case ConsoleKey.D4:
                case ConsoleKey.NumPad4:
                    Negyedik.Feladat();
                    break;
            }
            
        }
    }
}
