using System;
using System.Collections.Generic;

namespace Calculator.ServiceInterface
{
    public interface ICalculator
    {
        decimal Add(List<decimal> numbers);
        decimal Subtract(List<decimal> numbers);
        decimal Multiply(List<decimal> numbers);
        decimal Divide(List<decimal> numbers);
        List<decimal> SplitEq(List<decimal> numbers);
        decimal SplitNum(List<decimal> numbers);
    }
}
