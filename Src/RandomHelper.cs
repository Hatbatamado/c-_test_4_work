using System;

namespace test
{
    //Random szám segítő osztály, hogy a gyors lefutás miatt is különböző random számokat kapjunk
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
