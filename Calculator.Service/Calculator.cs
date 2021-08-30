using Calculator.ServiceInterface;
using System;
using System.Collections.Generic;

namespace Calculator.Service
{
    public class Calculator : ICalculator
    {
        public decimal Add(List<decimal> numbers)
        {
            if (numbers.Count > 1)
            {
                decimal tempNumber = 0;
                foreach (var num in numbers)
                {
                    tempNumber += num;
                }

                return tempNumber;
            }
            return 0.0m;
        }

        public decimal Subtract(List<decimal> numbers)
        {
            if (numbers.Count > 1)
            {
                decimal tempNumber = 0;
                foreach (var num in numbers)
                {
                    tempNumber = Math.Abs(tempNumber -  num);
                }

                return tempNumber;
            }
            return 0.0m;
        }

        public decimal Divide(List<decimal> numbers)
        {
            if (numbers.Count == 2)
            {
                return numbers[0] / numbers[1];
            }
            return 0.0m;
        }

        public decimal Multiply(List<decimal> numbers)
        {
            if (numbers.Count > 1)
            {
                decimal tempNumber = 1;
                foreach (var num in numbers)
                {

                    tempNumber *= num;
                }

                return tempNumber;
            }
            return 0.0m;
        }

        public List<decimal> SplitEq(List<decimal> numbers)
        {
            var list = new List<decimal>();
            if (numbers.Count == 2)
            {
                var x = numbers[0] / numbers[1];
                for (int i = 0; i < numbers[1]; i++)
                {
                    list.Add(x);
                }
            }
            return list;
        }

        public decimal SplitNum(List<decimal> numbers)
        {
            decimal tempNumber = 0;
            foreach (var num in numbers)
            {
                tempNumber = Math.Abs(tempNumber - num);
            }

            return tempNumber;
        }
    }
}
