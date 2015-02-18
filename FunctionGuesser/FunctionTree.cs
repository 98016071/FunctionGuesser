using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Instrumentation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace FunctionGuesser
{
    // It's root of tree, it's one node, that can have null child
    class FunctionTree : Node
    {
        public FunctionTree(INode left, INode right, Operator op)
            : base(left, right, op)
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

        public new void ChangeRandom()
        {
            if (Left == null || Right == null)
                InsertRandom();
            else
                base.ChangeRandom();
            if (Size / Configs.MaxSize / Tools.RandDouble() >= 1)
                DeleteRandom(0);
        }

        public new void Update()
        {
        }

        public new double GetValue(double x, double y)
        {
            if (Left != null && Right != null)
                return base.GetValue(x, y);
            if (Left != null)
                return Left.GetValue(x, y);
            if (Right != null)
                return Right.GetValue(x, y);
            return 0;
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
