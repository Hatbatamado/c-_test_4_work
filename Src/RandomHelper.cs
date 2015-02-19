using System;

namespace test
{
    //Véletlen szám segítő osztály, hogy a gyors lefutás miatt is különböző véletlen számokat kapjunk
    class RandomHelper
    {
        private static Random r = null;

        public static Random GetRandomGenerator
        {
            get
            {
                if (r == null)
                    r = new Random();
                return r;
            }
        }
    }
}
