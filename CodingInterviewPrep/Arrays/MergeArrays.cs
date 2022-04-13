using System;
using System.Collections.Generic;

namespace CodingInterviewPrep.Arrays
{
    public class MergeArrays
    {
        public IEnumerable<T> DoIt<T>(IEnumerable<T> first, IEnumerable<T> second) where T : IComparable
        {
            var solution = new List<T>();
            var i = first.GetEnumerator();
            var j = second.GetEnumerator();

            if (!i.MoveNext())
            {
                return second;
            }
            else if (!j.MoveNext())
            {
                return first;
            }

            while (true)
            {
                if (i.Current.CompareTo(j.Current) < 0)
                {
                    solution.Add(i.Current);
                    if (!i.MoveNext())
                    {
                        solution.Add(j.Current);
                        while (j.MoveNext())
                        {
                            solution.Add(j.Current);
                        }
                        return solution;
                    }
                }
                else
                {
                    solution.Add(j.Current);
                    if (!j.MoveNext())
                    {
                        solution.Add(i.Current);
                        while (i.MoveNext())
                        {
                            solution.Add(i.Current);
                        }
                        return solution;
                    }
                }
            }
        }

        public void Test()
        {

        }
    }
}
