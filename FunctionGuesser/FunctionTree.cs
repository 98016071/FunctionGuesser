using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FunctionGuesser
{
    // It's root of tree, it's one node, that can have null child
    class FunctionTree : Node
    {
        public FunctionTree(INode left, INode right, Operator op) : base(left, right, op)
        {
        }

        public new int Size
        {
            get
            {
                var cnt = 0;
                if (Left != null)
                    cnt += Left.Size;
                if (Right != null)
                    cnt += Right.Size;
                return cnt;
            }
        }

        public override string ToString()
        {
            if (Left != null && Right != null)
            {
                return base.ToString();
            }
            else if (Left != null)
            {
                return Left.ToString();
            }
            else if (Right != null)
            {
                return Right.ToString();
            }
            else
            {
                return "<None>";
            }
        }
    }
}
