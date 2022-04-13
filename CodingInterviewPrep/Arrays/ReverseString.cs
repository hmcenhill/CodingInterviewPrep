using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPrep.Arrays
{
    public class ReverseString
    {
        public string Go(string s)
        {
            var r = new StringBuilder();
            if (s != null && s.Length > 0)
            {
                for (var c = s.Length - 1; c >= 0; c--)
                {
                    r.Append(s[c]);
                }
            }
            return r.ToString();
        }

        public void Test()
        {
            var trials = 0;
            foreach (var kv in TestPass)
            {
                if (kv.Item1.Equals(Go(kv.Item2)))
                {
                    trials++;
                }
            }
            foreach (var kv in TestFail)
            {
                if (!kv.Item1.Equals(Go(kv.Item2)))
                {
                    trials++;
                }
            }
            Console.WriteLine($"Passed {trials} of {TestPass.Count + TestFail.Count} cases");

        }

        private static IList<(string, string)> TestPass = new List<(string, string)>
        {
            ("a", "a"),
            ("Hello World", "dlroW olleH"),
            ("hello world", "dlrow olleh"),
            ("", ""),
            ("", null),
        };

        private static IList<(string, string)> TestFail = new List<(string, string)>
        {
            ("a", "b"),
            ("a", "A"),
            ("Hello World", "dlrow olleh"),
            ("Hello World", "Hello World"),
            ("a", ""),
            ("a", null),
        };
    }
}
