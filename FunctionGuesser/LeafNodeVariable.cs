using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    class LeafNodeVariable : LeafNode
    {
        // This is leaf node, that contains variable
        private string strRepresentation;

        public LeafNodeVariable(string str)
        {
            str = str.ToLower();
            if (str != "x" && str != "y")
                throw new Exception("Incorrect variable name");
            strRepresentation = str;
        }
        public override INode Copy()
        {
            return new LeafNodeVariable(strRepresentation);
        }

        public override double GetValue(double x, double y)
        {
            return strRepresentation == "x" ? x : y;
        }

        public override string ToString()
        {
            return strRepresentation;
        }

        public static new LeafNodeVariable GenerateRandom()
        {
            var res = Tools.RandInt(0, 2);
            if (res == 0) 
                return new LeafNodeVariable("x");
            else
                return new LeafNodeVariable("y");
        }
    }
}
