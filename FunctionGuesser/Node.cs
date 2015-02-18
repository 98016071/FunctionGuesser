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
        private INode _left;
        public INode Left {
            get { return _left; }
            set
            {
                _left = value;
                if (value == null)
                {
                    Update();
                }
                else
                {
                    value.Parent = this;
                }
            } }
        private INode _right;
        public INode Right
        {
            get { return _right; }
            set
            {
                _right = value;
                if (value == null)
                {
                    Update();
                }
                else
                {
                    value.Parent = this;
                }
            }
        }
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
            var chanceLeft = Configs.ChanceChildNode;
            var chanceRight = Configs.ChanceChildNode;
            var chanceAdd = Configs.ChanceInsertNode;
            var chanceOperator = Configs.ChanceOperatorNode;
            var res = Tools.RandInt(0, chanceLeft + chanceRight + chanceAdd + chanceOperator);
            if (res < chanceLeft)
                Left.ChangeRandom();
            else if (res < chanceLeft + chanceRight)
                Right.ChangeRandom();
            else if (res < chanceLeft + chanceRight + chanceAdd)
                InsertRandom();
            else
                Operator = Operator.RandomOperator();
        }

        public void InsertRandom()
        {
            var node = new Node(Left, Right, Operator.RandomOperator());
            Left = node;
            Right = LeafNode.GenerateRandom();
        }

        public void DeleteRandom(int depth)
        {
            var chance = Configs.ChanceDelete * depth;
            if (Tools.RandDouble() <= chance)
                DeleteSubTree();
            else 
                if (Tools.RandDouble() <= 0.5)
                    Left.DeleteRandom(depth + 1);
                else
                    Right.DeleteRandom(depth + 1);
        }

        public void Replace(INode a, INode b)
        {
            if (Left == a)
            {
                Left = b;
                b.Parent = this;
            }
            else if (Right == a)
            {
                Right = b;
                b.Parent = this;
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
            else
            {
                throw new Exception("No such child." + child.ToString());
            }
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
            if (Left == null)
            {
                if (Right is LeafNode)
                {
                    if (Parent != null)
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
                if (Left is LeafNode)
                {
                    if (Parent != null)
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

        public override string ToString()
        {
            return "(" + Left.ToString() + Operator.ToString() + Right.ToString() + ")";
        }
    }
}
