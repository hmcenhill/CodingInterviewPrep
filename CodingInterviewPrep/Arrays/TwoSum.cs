using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPrep.Arrays
{
    public class TwoSum
    {
        public int[] Solution(int[] nums, int target)
        {
            var map = new HashSet<int>();
            for (var i = 0; i < nums.Length; i++)
            {
                if (map.Contains(target - nums[i]))
                {
                    return new[] { Array.IndexOf(nums, target - nums[i]), i };
                }
                map.Add(nums[i]);
            }
            return new[] { -1, -1 };
        }
    }
}
