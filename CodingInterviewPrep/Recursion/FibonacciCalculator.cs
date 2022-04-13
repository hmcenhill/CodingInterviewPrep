using System;
using System.Collections.Generic;

namespace CodingInterviewPrep.Recursion
{
    public class FibonacciCalculator
    {
        private IDictionary<int, int> knownValues;

        public FibonacciCalculator()
        {
            knownValues = new Dictionary<int, int>
            {
                [0] = 0,
                [1] = 1
            };
        }

        public void Test()
        {
            Console.WriteLine($"10th index of Fib is {FibonacciAtIndex(10)}");


            foreach(var kv in knownValues)
            {
                Console.WriteLine($"index {kv.Key} is {kv.Value}");
            }
        }

        public int FibonacciIndexOf(int value)
        {
            var index = 0;
            while (true)
            {
                var valAtIndex = FibonacciAtIndex(index);
                if (value == valAtIndex)
                {
                    return index;
                }
                if (value < valAtIndex)
                {
                    return -1;
                }
                index++;
            }
        }

        public int FibonacciAtIndex(int index)
        {
            if (index < 0) index = 0;
            if (knownValues.ContainsKey(index))
            {
                return knownValues[index];
            }
            var value = FibonacciAtIndex(index-1) + FibonacciAtIndex(index - 2);
            knownValues.Add(index, value);
            return value;
        }
    }
}
