using RPNCalculator.ConcreteImplementation;
using RPNCalculator.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace RPNCalculator
{
    public class RPNCalculator
    {
        public double Calculate(string expression)
        {
            Hashtable table = new Hashtable();
            table.Add("+", new AdditionOperation());
            table.Add("-", new SubtractionOperation());
            table.Add("*", new MultiplicationOperation());
            table.Add("/", new DivisionOperation());
            table.Add("!", new FactorialOperation());
            if (string.IsNullOrEmpty(expression))
            {
                throw new Exception("Invalid Expression");
            }
            Stack<string> expressionStack = new Stack<string>();
            double result = 0;
            string[] strArrray = expression.Split(',');
            double checkFirst = 0;
            if (double.TryParse(strArrray.First(), out checkFirst))
            {
                //if (strArrray.Last() == "+" || strArrray.Last() == "-" || strArrray.Last() == "*" || strArrray.Last() == "/")
                //{
                    for (int i = 0; i < strArrray.Length; i++)
                    {
                        if (strArrray[i] == "+" || strArrray[i] == "-" || strArrray[i] == "*" || strArrray[i] == "/")
                        {
                            double operand2 = Convert.ToDouble(expressionStack.Pop());
                            double operand1 = Convert.ToDouble(expressionStack.Pop());
                            ICalculateOnBinary calculate =(ICalculateOnBinary) table[strArrray[i]];
                            expressionStack.Push(calculate.Calculate(operand1, operand2).ToString());
                        }
                        else if(strArrray[i] == "!")
                        {
                            double operand = Convert.ToDouble(expressionStack.Pop());
                            ICalculateOnUnary calculate = (ICalculateOnUnary)table[strArrray[i]];
                            expressionStack.Push(calculate.Calculate(operand).ToString());
                        }
                        else
                        {
                            expressionStack.Push(strArrray[i].Trim());
                        }
                    }
                //}
                //else
                //{
                //    throw new Exception("No Operator at last");
                //}
            }
            else
            {
                throw new Exception("No Operand at first");
            }
            if(expressionStack.Count == 1)
            {
                result = Convert.ToInt32(expressionStack.Pop());
            }
            else
            {
                throw new Exception("Invalid Expression due to mismatch in operand");
            }
            return result;
        }
    }
}
