using System;

namespace test
{
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
