using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    static class Tools
    {
        private static Random rand;

        public static int RandInt(int min, int max)
        {
            if (rand == null)
                rand = new Random();
            return rand.Next(min, max);
        }

        public static double RandDouble()
        {
            if (rand == null)
                rand = new Random();
            return rand.NextDouble();
        }
    }
}
