using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    class Node : INode
    {
        public int Size
        {
            get { return Left.Size + Right.Size; } 
        }
        public Node Parent { get; set; }
        public Operator Operator { get; set; }
        public INode Left { get; set; }
        public INode Right { get; set; }
        public Node(INode left, INode right, Operator op)
        {
            Left = left;
            Right = right;
            Operator = op;
        }
        public INode Copy()
        {
            return new Node(Left.Copy(), Right.Copy(), Operator);
        }

        public void ChangeRandom()
        {
            Left.ChangeRandom();
        }

        public void DeleteRandom()
        {
            throw new NotImplementedException();
        }

        public void Replace(INode a, INode b)
        {
            if (Left == a)
            {
                Left = b;
            }
            else if (Right == a)
            {
                Right = b;
            }
            else
            {
                throw new Exception("No such child" + a.ToString());
            }
        } 
        public void DeleteChild(INode child)
        {
            if (child == Left)
                Left = null;
            else if (child == Right)
                Right = null;
            throw new Exception("No such child.");
        }
        public void DeleteSubTree()
        {
            Parent.DeleteChild(this);
        }

        public double GetValue(double x, double y)
        {
            return Operator.Compute(Left.GetValue(x, y), Right.GetValue(x, y));
        }

        public void Update()
        {
            if (Left != null && Right != null) 
                return;
            if (Parent == null)
            {
                if (Left != null)
                {
                    Left.Parent = null;
                }
                if (Right != null)
                {
                    Right.Parent = null;
                }
            }
            if (Left == null)
            {
                if (Right.GetType() == typeof(LeafNode))
                {
                    Parent.Replace(this, Right);
                    Right.Parent = Parent;
                }
                else
                {
                    ((Node)Right).UpdateParent();
                }
            }
            else if (Right == null)
            {
                if (Left.GetType() == typeof(LeafNode))
                {
                    Parent.Replace(this, Left);
                    Left.Parent = Parent;
                }
                else
                {
                    ((Node)Left).UpdateParent();
                }
            }
   
        }
        public void UpdateParent()
        {
            if (Parent == null)
            {
                throw new Exception("Parent is null, I can not delete myself.");
            }
            if (Parent.Left != null && Parent.Right != null)
            {
                throw new Exception("Parent has left and right children, I can not delete myself.");
            }
            Parent.Left = Left;
            Parent.Right = Right;
            Left.Parent = Parent;
            Right.Parent = Parent;
        }

        public string ToString()
        {
            return "(" + Left.ToString() + Operator.ToString() + Right.ToString() + ")";
        }
    }
}
