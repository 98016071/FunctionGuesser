using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    static class Configs
    {
        public static readonly int ChanceChildNode = 6;
        public static readonly int ChanceInsertNode = 3;
        public static readonly int ChanceOperatorNode = 3;

        public static readonly int ChanceChangeLeaf = 15;
        public static readonly int ChanceInsertLeaf = 3;
            
        public static readonly int ChanceNumber = 4;
        public static readonly int ChanceVariable = 1;

        public static readonly double ChanceDelete = 1/30;

    }
}
