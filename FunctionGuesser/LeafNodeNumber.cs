using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    // Here is leaf node, that contains constant
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

        public override string ToString()
        {
            return _value.ToString(CultureInfo.InvariantCulture);
        }

        public new static LeafNodeNumber GenerateRandom()
        {
            return new LeafNodeNumber(Tools.RandInt(0, 100)); //TODO: RandDouble() * 100
        }
    }
}
