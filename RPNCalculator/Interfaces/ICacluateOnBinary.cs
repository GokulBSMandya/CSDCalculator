using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator.Interfaces
{
    public interface ICalculateOnBinary:ICalculate
    {
        double Calculate(double operand1, double operand2);
    }
}
