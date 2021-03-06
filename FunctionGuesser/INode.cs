﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionGuesser
{
    interface INode
    {
        int Size { get; }
        Node Parent { get; set; }
        INode Copy();
        void ChangeRandom();
        void InsertRandom();
        void DeleteRandom(int depth);
        void DeleteSubTree();
        double GetValue(double x, double y);
    }
}
