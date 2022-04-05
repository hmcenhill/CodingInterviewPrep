using System;
using System.Collections.Generic;
using System.Linq;

namespace CodingInterviewPrep
{
    public class App
    {
        public void Run(int numberOfTrials = 2)
        {
            if (numberOfTrials < 2)
                numberOfTrials = 2;

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

            if (elapsedTimes.Count == 1)
            {
                Console.WriteLine($"Time to complete was {elapsedTimes.First()} ms.");
            }
            else
            {
                Console.WriteLine(
                    $"Completed {numberOfTrials} trials:\n" +
                    $"Average: {elapsedTimes.Average().ToString("0.0000")}ms\n" +
                    $"Fastest: {elapsedTimes.Min()}ms\n" +
                    $"Slowest: {elapsedTimes.Max()}ms");
            }
        }

        private double CalculateElapsedTime(DateTime startTime, DateTime stopTime) => (stopTime - startTime).TotalMilliseconds;

        private void Test()
        {
            // Add Test Case Here!


        }
    }
}
