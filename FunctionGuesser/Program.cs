using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            var node1 = new FunctionTree(new LeafNodeNumber(5), new Node(new LeafNodeNumber(7), new LeafNodeVariable("X"), Operator.MinusOperator), Operator.MultiplyOperator);
            while (true)
            {
                Console.WriteLine(node1 + " " + node1.Size + " " + node1.GetValue(10, 3));
                Console.ReadKey();
                node1.ChangeRandom();
            }
        }
    }
}
