using System;
using System.Collections.Generic;
using System.Text;

namespace CodingInterviewPrep.Arrays
{
    public class MaxSubArray
    {
        public int Solution(int[] nums)
        {
            var walker = 0;
            var currentSum = 0;
            var maxSum = int.MinValue;
            while (walker < nums.Length)
            {
                currentSum += nums[walker];
                if (currentSum > maxSum)
                {
                    maxSum = currentSum;
                }
                walker++;
                if (currentSum < 0)
                {
                    currentSum = 0;
                }
            }
            return maxSum;
        }
    }
}
