using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    abstract class LeafNode : INode
    {
        public int Size
        {
            get { return 1; }
        }
        public Node Parent { get; set; }
        public abstract INode Copy();
        public void ChangeRandom()
        {
            var chanceInsert = Configs.ChanceInsertLeaf;
            var chanceChange = Configs.ChanceChangeLeaf;
            var res = Tools.RandInt(0, chanceChange + chanceInsert);
            if (res < chanceInsert)
                InsertRandom();
            else 
                ReplaceRandom();
        }

        public void InsertRandom()
        {
            var parent = Parent;
            var node = new Node(this, GenerateRandom(), Operator.RandomOperator());
            parent.Replace(this, node);
        }

        public void DeleteRandom(int depth)
        {
            var chance = Configs.ChanceDelete * depth;
            if (Tools.RandDouble() <= chance)
                DeleteSubTree();
        }

        public void ReplaceRandom()
        {
            var ln = GenerateRandom();
            Parent.Replace(this, ln);
        }
        public static LeafNode GenerateRandom()
        {
            var chanceNumber = Configs.ChanceNumber;
            var chanceVariable = Configs.ChanceVariable;
            var res = Tools.RandInt(0, chanceNumber + chanceVariable);
            if (res < chanceNumber)
                return LeafNodeNumber.GenerateRandom();
            else
                return LeafNodeVariable.GenerateRandom();
        }
        public void DeleteSubTree()
        {
            Parent.DeleteChild(this);
        }
        public abstract double GetValue(double x, double y);
    }
}
