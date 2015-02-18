using System;
using System.Collections.Generic;
using System.Linq;
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
            throw new NotImplementedException(); 
        }
        public void DeleteRandom()
        {
            throw new NotImplementedException(); 
        }
        public void DeleteSubTree()
        {
            Parent.DeleteChild(this);
        }
        public abstract double GetValue(double x, double y);
    }
}
