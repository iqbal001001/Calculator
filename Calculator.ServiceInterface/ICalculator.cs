using System;
using System.Collections.Generic;

namespace Calculator.ServiceInterface
{
    public interface ICalculator
    {
        decimal Add(decimal number1, decimal number2);
        decimal Subtract(decimal number1, decimal number2);
        decimal Multiply(decimal number1, decimal number2);
        decimal Divide(decimal number1, decimal number2);
        List<decimal> SplitEq(decimal number1, decimal number2);
        decimal SplitNum(List<decimal> numbers);
    }
}
