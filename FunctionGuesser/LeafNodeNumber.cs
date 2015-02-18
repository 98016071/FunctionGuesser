using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    class LeafNodeNumber : LeafNode
    {
        private readonly double _value;

        public LeafNodeNumber(double value)
        {
            _value = value;
        }
        public override INode Copy()
        {
            return new LeafNodeNumber(_value);
        }

        public override double GetValue(double x, double y)
        {
            return _value;
        }
    }
}
