using System;
using System.Collections.Generic;

namespace CodingInterviewPrep.Recursion
{
    public class FactorialCalculator
    {
        public int Factorial(int value) => value <= 1 ? 1 : value * Factorial(value - 1);

        public void Test()
        {
            foreach (var val in TestCases)
            {
                Console.WriteLine($"{val}! = {Factorial(val)}");
            }
        }

        private static IList<int> TestCases = new List<int>
        {
            -1,0,1,2,3,4,5,6,7,8,9,10
        };
    }
}
