using CodingInterviewPrep.Arrays;
using CodingInterviewPrep.Graphs;
using CodingInterviewPrep.Recursion;
using CodingInterviewPrep.Trees;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterviewPrep
{
    public class App
    {
        public void Run() => Run(GetTrialsFromConsole());

        private int GetTrialsFromConsole()
        {
            Console.WriteLine("Enter number of trials to run: ");
            var input = Console.ReadLine();

            if (int.TryParse(input, out var value))
            {
                return value;
            }
            return -1;
        }

        public void Run(int numberOfTrials)
        {
            if (numberOfTrials < 0)
                numberOfTrials = 1;

            var elapsedTimes = new List<double>();
            for (var i = 0; i < numberOfTrials; i++)
            {
                var startTime = DateTime.Now;
                Test();
                var stopTime = DateTime.Now;

                if (i != 0) // Throw out the first one
                {
                    elapsedTimes.Add(CalculateElapsedTime(startTime, stopTime));
                }
            }

            if (elapsedTimes.Count > 1)
            {
                Console.WriteLine(
                    $"\nCompleted {numberOfTrials} trials:\n" +
                    $"Average: {elapsedTimes.Average().ToString("0.0000")}ms\n" +
                    $"Fastest: {elapsedTimes.Min()}ms\n" +
                    $"Slowest: {elapsedTimes.Max()}ms");
            }
        }

        private double CalculateElapsedTime(DateTime startTime, DateTime stopTime) => (stopTime - startTime).TotalMilliseconds;

        private void Test()
        {
            // Add Test Case Here!

            //new FactorialCalculator().Test();
            new FibonacciCalculator().Test();
        }
    }
}
