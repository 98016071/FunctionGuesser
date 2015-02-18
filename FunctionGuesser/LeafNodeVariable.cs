using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    class LeafNodeVariable : LeafNode
    {
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
    }
}
