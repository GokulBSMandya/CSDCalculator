using RPNCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.ConcreteImplementation
{
    class FactorialOperation : ICalculateOnUnary
    {
        public double Calculate(double operand)
        {
            double result = 1.0;
            if (operand == 0)
                return result;
            else
            {
                for (double i = operand; i > 1; i--)
                {
                    result = result * i;
                }
            }
            return result;
        }

    }
}
