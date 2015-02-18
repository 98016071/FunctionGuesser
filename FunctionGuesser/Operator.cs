using System;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;

namespace FunctionGuesser
{
    enum OperatorType
    {
        Plus, Minus, Multiply, Divide
    }

    class Operator
    {
        private OperatorType type;
        private string str;
        private const int Cnt = 4;

        public static Operator PlusOperator = new Operator(OperatorType.Plus, "+");
        public static Operator MinusOperator = new Operator(OperatorType.Minus, "-");
        public static Operator MultiplyOperator = new Operator(OperatorType.Multiply, "*");
        public static Operator DivideOperator = new Operator(OperatorType.Divide, "/");
        private Operator(OperatorType t, string s)
        {
            type = t;
            str = s;
        }

        public double Compute(double a, double b)
        {
            switch (type)
            {
                case OperatorType.Plus:
                    {
                        return a + b;
                    }
                case OperatorType.Minus:
                    {
                        return a - b;
                    }
                case OperatorType.Multiply:
                    {
                        return a * b;
                    }
                case OperatorType.Divide:
                    {
                        return a / b;
                    }
                default:
                    {
                        throw new ArithmeticException("I don't know this operator :(");
                    }
            }
        }

        public static Operator RandomOperator()
        {
            switch (Tools.RandInt(0, Cnt))
            {
                case 0:
                    return PlusOperator;
                case 1:
                    return MinusOperator;
                case 2:
                    return MultiplyOperator;
                case 3:
                    return DivideOperator;
            }
            return null;
        }

        public override string ToString()
        {
            return " " + str + " ";
        }
    }
}