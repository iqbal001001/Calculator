using Calculator.ServiceInterface;
using System;
using System.Collections.Generic;

namespace Calculator.Service
{
    public class Calculator : ICalculator
    {
        public decimal Add(decimal number1, decimal number2)
        {
            return number1 + number2;
        }

        public decimal Subtract(decimal number1, decimal number2)
        {
            return number1 - number2;
        }

        public decimal Divide(decimal number1, decimal number2)
        {
            return number1 / number2;
        }

        public decimal Multiply(decimal number1, decimal number2)
        {
            return number1 * number2;
        }

        public List<decimal> SplitEq(decimal number1, decimal number2)
        {
            var list = new List<decimal>();
            var x = number1 / number2;
            for(int i = 0; i< number2; i++)
            {
                list.Add(x);
            }
            return list;
        }

        public decimal SplitNum(List<decimal> numbers)
        {
            decimal tempNumber = 0;
            foreach(var num in numbers)
            {
                if (tempNumber == 0) {
                    tempNumber = num;
                    continue;
                }

                tempNumber -= num;
            }

            return tempNumber;
        }
    }
}
