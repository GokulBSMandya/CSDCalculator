using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPNCalculator
{
    [TestFixture]
    class RPNCalculatorTest
    {
        [Test]
        public void AddTwoOperands()
        {
            string expression = "2,3,+";
            RPNCalculator calculator = new RPNCalculator();
            Assert.AreEqual(5, calculator.Calculate(expression));
        }

        [Test]
        public void AddThreeOperands()
        {
            string expression = "2,3,+,4,+";
            RPNCalculator calculator = new RPNCalculator();
            Assert.AreEqual(9, calculator.Calculate(expression));
        }

        [Test]
        public void AddNoSufficientOperator()
        {
            try
            {
                string expression = "2,3,+,4";
                RPNCalculator calculator = new RPNCalculator();
                calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid Expression due to mismatch in operand", ex.Message);
            }
        }

        [Test]
        public void AddNoOperandFirst()
        {
            try
            {
                string expression = "+,3,4";
                RPNCalculator calculator = new RPNCalculator();
                calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("No Operand at first", ex.Message);
            }
        }

        [Test]
        public void NumberofOprands()
        {
            try
            {
                string expression = "2,3,4,+";
                RPNCalculator calculator = new RPNCalculator();
                calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid Expression due to mismatch in operand", ex.Message);
            }
        }

        [Test]
        public void NullExpression()
        {
            try
            {
                string expression = "";
                RPNCalculator calculator = new RPNCalculator();
                calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Invalid Expression", ex.Message);
            }
        }
        [Test]
        public void InvalidOperation()
        {
            try
            {
                string expression = "2,3,+,+";
                RPNCalculator calculator = new RPNCalculator();
                calculator.Calculate(expression);
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Stack empty.", ex.Message);
            }
        }

        [Test]
        public void PassExpressRPN()
        {
                string expression = "5,1,2,+,4,*,+,3,-";
                RPNCalculator calculator = new RPNCalculator();
                Assert.AreEqual(14,calculator.Calculate(expression));
        }

        [Test]
        public void PassExpressRPNwithFactorial()
        {
            string expression = "5,1,2,+,4,*,+,3,-,10,-,!";
            RPNCalculator calculator = new RPNCalculator();
            Assert.AreEqual(24, calculator.Calculate(expression));
        }

        [Test]
        public void CheckFactorialOnly()
        {
            string expression = "5,!";
            RPNCalculator calculator = new RPNCalculator();
            Assert.AreEqual(120, calculator.Calculate(expression));
        }

        [Test]
        public void CheckMultiplyDivision()
        {
            string expression = "6,2 ,*,3,/";
            RPNCalculator calculator = new RPNCalculator();
            Assert.AreEqual(4, calculator.Calculate(expression));
        }

        [Test]
        public void CheckDivision()
        {
            string expression = "3,!,4,5,*,+";
            RPNCalculator calculator = new RPNCalculator();
            Assert.AreEqual(26, calculator.Calculate(expression));
        }

    }
}
