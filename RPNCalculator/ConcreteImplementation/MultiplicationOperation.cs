using RPNCalculator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.ConcreteImplementation
{
    public class MultiplicationOperation : ICalculateOnBinary
    {
        public double Calculate(double operand1, double operand2)
        {
            return operand1 * operand2;
        }
    }
}
